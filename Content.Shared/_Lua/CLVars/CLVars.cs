// LuaWorld - This file is licensed under AGPLv3
// Copyright (c) 2025 LuaWorld
// See AGPLv3.txt for details.

using Robust.Shared.Configuration;

namespace Content.Shared.Lua.CLVar
{
    [CVarDefs]
    public sealed partial class CLVars
    {
        public static readonly CVarDef<bool> BankFlushCacheEnabled = CVarDef.Create("bank.flushcache.enabled", false, CVar.SERVER | CVar.REPLICATED);
        public static readonly CVarDef<int> BankFlushCacheInterval = CVarDef.Create("bank.flushcache.interval", 300, CVar.SERVER | CVar.REPLICATED);

        public static readonly CVarDef<bool> NetDynamicTick =
            CVarDef.Create("net.dynamictick", false, CVar.ARCHIVE | CVar.SERVER | CVar.REPLICATED);

        /// <summary>
        /// Whether to automatically spawn escape shuttles.
        /// </summary>
        public static readonly CVarDef<bool> GridFillCentcomm =
            CVarDef.Create("shuttle.grid_fill_centcom", true, CVar.SERVERONLY);

        /// <summary>
        /// Включение/отключение Автоудаления Шаттлов..
        /// </summary>
        public static readonly CVarDef<bool> AutoDelteEnabled =
            CVarDef.Create("zone.autodelete_enabled", true, CVar.SERVERONLY | CVar.ARCHIVE,
                "Отключить или включить автоудаление шаттлов.");

        /// <summary>
        /// Включение/отключение PVE-зон..
        /// </summary>
        public static readonly CVarDef<bool> PveEnabled =
            CVarDef.Create("zone.pve_enabled", false, CVar.SERVERONLY | CVar.ARCHIVE,
                "Отключить или включить пве зоны.");

        /// <summary>
        /// Включение/отключение PVP-зон..
        /// </summary>
        public static readonly CVarDef<bool> PvpEnabled =
            CVarDef.Create("zone.pvp_enabled", false, CVar.SERVERONLY | CVar.ARCHIVE,
                "Отключить или включить пвп зоны.");

        /// <summary>
        ///     Whether or not to generate FTL points roundstart.
        /// </summary>
        public static readonly CVarDef<bool> GenerateStarmapRoundstart =
            CVarDef.Create("starmap.generate_roundstart", false, CVar.ARCHIVE);

        /// <summary>
        ///     What weighted random prototype is being used?
        /// </summary>
        public static readonly CVarDef<string> StarmapRandomPrototypeId =
            CVarDef.Create("starmap.weighted_random_id", "DefaultStarmap", CVar.ARCHIVE);

        public static readonly CVarDef<string> RabbitMQConnectionString =
            CVarDef.Create("rabbitmq.connection_string", "", CVar.SERVERONLY);

        public static readonly CVarDef<bool> IsERP =
            CVarDef.Create("ic.erp", false, CVar.SERVER | CVar.REPLICATED);

        /*
         *  World Gen
         */
        /// <summary>
        /// The number of Trade Stations to spawn in every round
        /// </summary>
        public static readonly CVarDef<int> AsteroidMarketStations =
            CVarDef.Create("lua.worldgen.asteroid_market_stations", 1, CVar.SERVERONLY);
        public static readonly CVarDef<int> TypanMarketStations =
            CVarDef.Create("lua.worldgen.typan_market_stations", 1, CVar.SERVERONLY);

        /// <summary>
        /// The number of Cargo Depots to spawn in every round
        /// </summary>
        public static readonly CVarDef<int> AsteroidCargoDepots =
            CVarDef.Create("lua.worldgen.asteroid_cargo_depots", 4, CVar.SERVERONLY);
        public static readonly CVarDef<int> TypanCargoDepots =
            CVarDef.Create("lua.worldgen.typan_cargo_depots", 1, CVar.SERVERONLY);

        public static readonly CVarDef<bool> AsteroidSectorEnabled =
            CVarDef.Create("game.asteroid_sector_enabled", false, CVar.SERVERONLY);

        /// <summary>
        /// Интервал автоматической выдачи зарплаты в секундах 3600 = 1 час.
        /// </summary>
        public static readonly CVarDef<float> AutoSalaryInterval =
            CVarDef.Create("salary.auto_interval", 3600f, CVar.SERVER | CVar.ARCHIVE);

        /// <summary>
        /// Включение/отключение автo-удаления мелких гридов.
        /// </summary>
        public static readonly CVarDef<bool> AutoGridCleanupEnabled =
            CVarDef.Create("shuttle.grid_cleanup_enabled", true, CVar.SERVERONLY | CVar.ARCHIVE);
    }
}
