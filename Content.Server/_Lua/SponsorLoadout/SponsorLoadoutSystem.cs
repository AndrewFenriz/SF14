using System.Linq;
using Content.Shared.GameTicking;
using Content.Server.Hands.Systems;
using Content.Shared._Lua.SponsorLoadout;
using Robust.Shared.Prototypes;
using Content.Shared.Humanoid;
using Content.Shared.Roles;
using Content.Shared.Station;

namespace Content.Server._Lua.SponsorLoadout;

public sealed class SponsorLoadoutSystem : EntitySystem
//Упрощенная система выдачи вещей для доминаторов
{
    [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
    [Dependency] private readonly HandsSystem _handsSystem = default!;

    public override void Initialize()
    {
        SubscribeLocalEvent<PlayerSpawnCompleteEvent>(OnPlayerSpawned);
    }

            private void OnPlayerSpawned(PlayerSpawnCompleteEvent ev)
    {
        var sponsorLoadouts = _prototypeManager.EnumeratePrototypes<SponsorLoadoutPrototype>();

        foreach (var loadout in sponsorLoadouts)
        {
            if (ShouldGiveLoadout(loadout, ev))
            {
                GiveLoadout(loadout, ev);
            }
        }
    }

        private bool ShouldGiveLoadout(SponsorLoadoutPrototype loadout, PlayerSpawnCompleteEvent ev)
    {
        if (loadout.WhitelistJobs != null && loadout.WhitelistJobs.Count > 0)
        {
            if (ev.JobId == null || !loadout.WhitelistJobs.Contains(ev.JobId))
                return false;
        }

        if (loadout.BlacklistJobs != null && loadout.BlacklistJobs.Count > 0)
        {
            if (ev.JobId != null && loadout.BlacklistJobs.Contains(ev.JobId))
                return false;
        }

        if (loadout.SpeciesRestrictions != null && loadout.SpeciesRestrictions.Count > 0)
        {
            if (loadout.SpeciesRestrictions.Contains(ev.Profile.Species))
                return false;
        }

        if (!string.IsNullOrEmpty(loadout.Login))
        {
            if (!string.Equals(ev.Player.Name, loadout.Login, StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }

        private void GiveLoadout(SponsorLoadoutPrototype loadout, PlayerSpawnCompleteEvent ev)
    {
        try
        {
            var entity = Spawn(loadout.EntityId, Transform(ev.Mob).Coordinates);
            _handsSystem.TryPickup(ev.Mob, entity);

            Logger.Info($"Выдан '{loadout.ID}' доминатору '{ev.Player.Name}'");
        }
        catch (Exception ex)
        {
            Logger.Error($"Ошибка выдачи '{loadout.ID}' доминатору '{ev.Player.Name}': {ex.Message}");
        }
    }
}
