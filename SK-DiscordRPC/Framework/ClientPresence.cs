﻿using DiscordRPC;
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

        private static void set(string detail, string state, string largeImageKey, string largeImageDesc)
        {
            AppWindow.client.SetPresence(new RichPresence()
            {
                Details = detail,
                State = state,
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageDesc
                }
            });
        }

        public static void update()
        {
            string detail = null;
            string state = null;
            string largeImageKey = null;
            string largeImageDesc = null;
            Whereabout where = Parser.parseWhereabout();
            string curIdent = AppWindow.curWhere.getIdent();
            if (where.getIdent() != curIdent)
            {
                switch (where.getIdent())
                {
                    case IdentCodes.IDENT_GENERIC_CLOCKWORKS:
                        if (curIdent != IdentCodes.IDENT_MISSION_LOBBY
                            && curIdent != IdentCodes.IDENT_HOI_LOBBY
                            && curIdent != IdentCodes.IDENT_GITM_LOBBY)
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
                        largeImageKey = ImageCodes.IMAGE_MOORCROFT_MANOR;
                        largeImageDesc = "Moorcroft Manor";
                        break;
                    case IdentCodes.IDENT_EMBERLIGHT:
                        detail = "In Emberlight";
                        largeImageKey = ImageCodes.IMAGE_EMBERLIGHT;
                        largeImageDesc = "Emberlight";
                        break;
                    case IdentCodes.IDENT_MISSION_LOBBY:
                        detail = "In a Mission";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "Mission";
                        break;
                    case IdentCodes.IDENT_HOI_LOBBY:
                        detail = "In Heart of Ice";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_GITM_LOBBY:
                        detail = "In Ghosts in the Machine";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_C42_LOBBY:
                        detail = "In Compound 42";
                        largeImageKey = ImageCodes.IMAGE_GENERIC_CLOCKWORKS;
                        largeImageDesc = "Danger Mission";
                        break;
                    case IdentCodes.IDENT_TORTODRONES_LOBBY:
                        detail = "In March of the Tortodrones";
                        largeImageKey = ImageCodes.IMAGE_TORTODRONES;
                        largeImageDesc = "March of the Tortodrones";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS:
                        detail = "In GWW";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS;
                        largeImageDesc = "Gloaming Wildwoods";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE:
                        detail = "In RJP";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE;
                        largeImageDesc = "Royal Jelly Palace";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY:
                        detail = "In IMF";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY;
                        largeImageDesc = "Iron Munitions Factory";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_D24:
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_D25:
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_D26:
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_D27:
                        detail = "In FSC";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL;
                        largeImageDesc = "Firestorm Citadel";
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
                        detail = "In Dreams and Nightmares";
                        largeImageKey = ImageCodes.IMAGE_DREAMS_AND_NIGHTMARES;
                        largeImageDesc = "Dreams and Nightmares";
                        break;
                    case IdentCodes.IDENT_GUILDHALL:
                        detail = "In a Guild Hall";
                        largeImageKey = ImageCodes.IMAGE_GUILDHALL;
                        largeImageDesc = "A Guild Hall";
                        break;
                    default:
                        return;
                }
                if (!AppContext.HIDE_KNIGHT)
                {
                    state = "Knight: " + Parser.parseKnightName();
                }
                else
                {
                    state = "Knight: [hidden]";
                }
                set(detail, state, largeImageKey, largeImageDesc);
                AppWindow.curWhere = where;
            }
        }

    }
}
