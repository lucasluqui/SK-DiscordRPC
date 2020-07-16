using DiscordRPC;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SK_DiscordRPC.Framework
{
    public static class ClientPresence
    {

        private static string knightName = null;

        private static void set(string detail, string largeImageKey, string largeImageDesc)
        {
            if (Properties.Settings.Default.ShowKnight)
            {
                AppWindow.client.SetPresence(new RichPresence()
                {
                    Details = detail,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageDesc,
                        SmallImageKey = "knight",
                        SmallImageText = "Knight: " + knightName
                    }
                });
            }
            else
            {
                AppWindow.client.SetPresence(new RichPresence()
                {
                    Details = detail,
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageDesc
                    }
                });
            }
        }

        public static void update()
        {
            string detail = null;
            string largeImageKey = null;
            string largeImageDesc = null;
            knightName = Parser.parseKnightName();
            Whereabout where = Parser.parseWhereabout();
            string curIdent = AppWindow.curWhere.getIdent();
            if (where.getIdent() != curIdent)
            {
                switch (where.getIdent())
                {
                    case IdentCodes.IDENT_GENERIC_CLOCKWORKS:
                        if (curIdent != IdentCodes.IDENT_MISSION_LOBBY
                            && curIdent != IdentCodes.IDENT_HOI_LOBBY
                            && curIdent != IdentCodes.IDENT_GITM_LOBBY
                            && curIdent != IdentCodes.IDENT_C42_LOBBY
                            && curIdent != IdentCodes.IDENT_LOA_LOBBY
                            && curIdent != IdentCodes.IDENT_DREAMS_AND_NIGHTMARES)
                        {
                            detail = "In The Clockworks";
                            largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                            largeImageDesc = "The Clockworks";
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case IdentCodes.IDENT_READY_ROOM:
                        detail = "In Ready Room";
                        largeImageKey = ImageCodes.IMAGE_READY_ROOM;
                        largeImageDesc = "Ready Room";
                        break;
                    case IdentCodes.IDENT_TOWN_SQUARE:
                    case IdentCodes.IDENT_TOWN_SQUARE_EX:
                        detail = "In Town Square";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Haven";
                        break;
                    case IdentCodes.IDENT_BAZAAR:
                        detail = "In Bazaar";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Haven";
                        break;
                    case IdentCodes.IDENT_ARCADE:
                        detail = "In Arcade";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Haven";
                        break;
                    case IdentCodes.IDENT_GARRISON:
                        detail = "In Garrison";
                        largeImageKey = ImageCodes.IMAGE_HAVEN;
                        largeImageDesc = "Haven";
                        break;
                    case IdentCodes.IDENT_ARCADE_STARTPOINT:
                        detail = "Starting an Arcade run";
                        largeImageKey = ImageCodes.IMAGE_LOBBY;
                        largeImageDesc = "Lobby";
                        break;
                    case IdentCodes.IDENT_ARCADE_TERMINAL:
                    case IdentCodes.IDENT_ARCADE_TERMINAL_SL:
                        detail = "In a Terminal";
                        largeImageKey = ImageCodes.IMAGE_TERMINAL;
                        largeImageDesc = "Terminal";
                        break;
                    case IdentCodes.IDENT_MOORCROFT_MANOR:
                        detail = "In Moorcroft Manor";
                        largeImageKey = ImageCodes.IMAGE_SUBTOWN;
                        largeImageDesc = "Moorcroft Manor";
                        break;
                    case IdentCodes.IDENT_EMBERLIGHT:
                        detail = "In Emberlight";
                        largeImageKey = ImageCodes.IMAGE_SUBTOWN;
                        largeImageDesc = "Emberlight";
                        break;
                    case IdentCodes.IDENT_MISSION_LOBBY:
                        detail = "In a Mission";
                        largeImageKey = ImageCodes.IMAGE_MISSION;
                        largeImageDesc = "Mission";
                        break;
                    case IdentCodes.IDENT_HOI_LOBBY:
                        detail = "In Heart of Ice";
                        largeImageKey = ImageCodes.IMAGE_HOI;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_GITM_LOBBY:
                        detail = "In Ghosts in the Machine";
                        largeImageKey = ImageCodes.IMAGE_GITM;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_C42_LOBBY:
                        detail = "In Compound 42";
                        largeImageKey = ImageCodes.IMAGE_C42;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_LOA_LOBBY:
                        detail = "In Legion of Almire";
                        largeImageKey = ImageCodes.IMAGE_LOA;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_TORTODRONES_LOBBY:
                        detail = "In March of the Tortodrones";
                        largeImageKey = ImageCodes.IMAGE_TORTODRONES;
                        largeImageDesc = "March of the Tortodrones";
                        break;
                    case IdentCodes.IDENT_HARVESTER_LOBBY:
                        detail = "In Apocrea";
                        largeImageKey = ImageCodes.IMAGE_TORTODRONES;
                        largeImageDesc = "Shroud of the Apocrea";
                        break;
                    case IdentCodes.IDENT_SPARKDUMP_LOBBY:
                        detail = "In GA";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "Grinchlin Assault";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F1:
                        detail = "In GWW (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS;
                        largeImageDesc = "Gloaming Wildwoods (Terrilous Trail)";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F2:
                        detail = "In GWW (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS;
                        largeImageDesc = "Gloaming Wildwoods (Roarsterous Ruins)";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F3:
                        detail = "In GWW (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS_BOSS;
                        largeImageDesc = "Gloaming Wildwoods (Lair of the Snarbolax)";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F1:
                        detail = "In RJP (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE;
                        largeImageDesc = "Royal Jelly Palace (Garden of Goo)";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F2:
                        detail = "In RJP (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE;
                        largeImageDesc = "Royal Jelly Palace (Red Carpet Runaround)";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F3:
                        detail = "In RJP (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE_BOSS;
                        largeImageDesc = "Royal Jelly Palace (Battle Royale)";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F1:
                        detail = "In IMF (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY;
                        largeImageDesc = "Iron Munitions Factory (Abandoned Assembly)";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F2:
                        detail = "In IMF (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY;
                        largeImageDesc = "Iron Munitions Factory (Warfare Workshop)";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F3:
                        detail = "In IMF (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY_BOSS;
                        largeImageDesc = "Iron Munitions Factory (The Roarmulus Twins)";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F1:
                        detail = "In FSC (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel (Blackstone Bridge)";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F2:
                        detail = "In FSC (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel (Charred Court)";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F3:
                        detail = "In FSC (Floor 3)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel (Ashen Armory)";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F4:
                        detail = "In FSC (Floor 4)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel (Smoldering Steps)";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F5:
                        detail = "In FSC (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_BOSS;
                        largeImageDesc = "Firestorm Citadel (Throne Room)";
                        break;
                    case IdentCodes.IDENT_OCH:
                        detail = "In OCH";
                        largeImageKey = ImageCodes.IMAGE_OCH;
                        largeImageDesc = "Operation Crimson Hammer";
                        break;
                    case IdentCodes.IDENT_THE_CORE:
                        detail = "In The Core";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "The Core";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES:
                        detail = "In DaN";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "Dreams and Nightmares";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES_F3:
                        detail = "In DaN (Floor 3)";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "Dreams and Nightmares (Descent into Darkness)";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES_END:
                        detail = "In DaN (End)";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "Dreams and Nightmares (Refuge)";
                        break;
                    case IdentCodes.IDENT_GUILDHALL:
                        detail = "In a Guild Hall";
                        largeImageKey = ImageCodes.IMAGE_GUILDHALL;
                        largeImageDesc = "A Guild Hall";
                        break;
                    case IdentCodes.IDENT_GUILDHALL_GYM_T1:
                    case IdentCodes.IDENT_GUILDHALL_GYM_T2:
                    case IdentCodes.IDENT_GUILDHALL_GYM_T3:
                        detail = "In a Guild Training Hall";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "A Guild Training Hall";
                        break;
                    default:
                        return;
                }
                set(detail, largeImageKey, largeImageDesc);
                AppWindow.curWhere = where;
            }
        }

    }
}
