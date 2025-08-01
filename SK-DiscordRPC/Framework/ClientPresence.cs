using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using DiscordRPC;

using SK_DiscordRPC.Data;
using SK_DiscordRPC.Util;

namespace SK_DiscordRPC.Framework
{
    public static class ClientPresence
    {

        private static string knightName = null;

        private static void set (string detail, string largeImageKey, string largeImageDesc)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            if (Properties.Settings.Default.ShowKnight)
            {
                AppWindow.discordClient.SetPresence(new RichPresence()
                {
                    Type = ActivityType.Playing,
                    Details = detail,
                    State = "(KL v" + AppWindow.KL_VERSION + ", RPC v" + AppWindow.RPC_VERSION + ")",
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageDesc,
                        SmallImageKey = "knight",
                        SmallImageText = "Knight: " + knightName
                    },
                    Buttons = new Button[]
                    {
                        new Button() { 
                            Label = "Get Knight Launcher", 
                            Url = "https://github.com/lucasluqui/KnightLauncher"
                        }
                    }
                });
            }
            else
            {
                AppWindow.discordClient.SetPresence(new RichPresence()
                {
                    Type = ActivityType.Playing,
                    Details = detail,
                    State = "(KL v" + AppWindow.KL_VERSION + ", RPC v" + AppWindow.RPC_VERSION + ")",
                    Timestamps = Timestamps.Now,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageDesc
                    },
                    Buttons = new Button[]
                    {
                        new Button() {
                            Label = "Get Knight Launcher",
                            Url = "https://github.com/lucasluqui/KnightLauncher"
                        }
                    }
                });
            }
        }

        public static void update ()
        {
            string detail = null;
            string largeImageKey = null;
            string largeImageDesc = null;
            knightName = Parser.parseKnightName();
            Whereabouts whereabouts = Parser.parseWhereabouts();
            string currentIdent = AppWindow.currentWhereabouts.getIdent();
            if (whereabouts.getIdent() != currentIdent)
            {
                switch (whereabouts.getIdent())
                {
                    case IdentCodes.IDENT_GENERIC_CLOCKWORKS:
                        if (currentIdent != IdentCodes.IDENT_MISSION_LOBBY
                            && currentIdent != IdentCodes.IDENT_HOI_LOBBY
                            && currentIdent != IdentCodes.IDENT_GITM_LOBBY
                            && currentIdent != IdentCodes.IDENT_C42_LOBBY
                            && currentIdent != IdentCodes.IDENT_LOA_LOBBY
                            && currentIdent != IdentCodes.IDENT_DREAMS_AND_NIGHTMARES)
                        {
                            detail = "Travelling The Clockworks";
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
                        largeImageKey = ImageCodes.IMAGE_HAVEN_DEFAULT;
                        largeImageDesc = "Haven - Town Square";
                        break;
                    case IdentCodes.IDENT_BAZAAR:
                        detail = "In Bazaar";
                        largeImageKey = ImageCodes.IMAGE_HAVEN_DEFAULT_BAZAAR;
                        largeImageDesc = "Haven - Bazaar";
                        break;
                    case IdentCodes.IDENT_ARCADE:
                        detail = "In Arcade";
                        largeImageKey = ImageCodes.IMAGE_HAVEN_DEFAULT_ARCADE;
                        largeImageDesc = "Haven - Arcade";
                        break;
                    case IdentCodes.IDENT_GARRISON:
                        detail = "In Garrison";
                        largeImageKey = ImageCodes.IMAGE_HAVEN_DEFAULT_GARRISON;
                        largeImageDesc = "Haven - Garrison";
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
                        largeImageKey = ImageCodes.IMAGE_SUBTOWN_MOORCROFT;
                        largeImageDesc = "Moorcroft Manor";
                        break;
                    case IdentCodes.IDENT_EMBERLIGHT:
                        detail = "In Emberlight";
                        largeImageKey = ImageCodes.IMAGE_SUBTOWN_EMBERLIGHT;
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
                        largeImageKey = ImageCodes.IMAGE_HARVESTER;
                        largeImageDesc = "Shroud of the Apocrea";
                        break;
                    case IdentCodes.IDENT_SPARKDUMP_LOBBY:
                        detail = "In Grinchlin Assault";
                        largeImageKey = ImageCodes.IMAGE_SPARKDUMP;
                        largeImageDesc = "Grinchlin Assault";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F1:
                        detail = "In Gloaming Wildwoods (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS_F1;
                        largeImageDesc = "Terrilous Trail";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F2:
                        detail = "In Gloaming Wildwoods (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS_F2;
                        largeImageDesc = "Roarsterous Ruins";
                        break;
                    case IdentCodes.IDENT_GLOAMING_WILDWOODS_F3:
                        detail = "In Gloaming Wildwoods (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_GLOAMING_WILDWOODS_BOSS;
                        largeImageDesc = "Lair of the Snarbolax";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F1:
                        detail = "In Royal Jelly Palace (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE_F1;
                        largeImageDesc = "Garden of Goo";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F2:
                        detail = "In Royal Jelly Palace (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE_F2;
                        largeImageDesc = "Red Carpet Runaround";
                        break;
                    case IdentCodes.IDENT_JELLY_PALACE_F3:
                        detail = "In Royal Jelly Palace (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_JELLY_PALACE_BOSS;
                        largeImageDesc = "Battle Royale";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F1:
                        detail = "In Ironclaw Munitions Factory (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY_F1;
                        largeImageDesc = "Abandoned Assembly";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F2:
                        detail = "In Ironclaw Munitions Factory (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY_F2;
                        largeImageDesc = "Warfare Workshop";
                        break;
                    case IdentCodes.IDENT_MUNITIONS_FACTORY_F3:
                        detail = "In Ironclaw Munitions Factory (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_MUNITIONS_FACTORY_BOSS;
                        largeImageDesc = "The Roarmulus Twins";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F1:
                        detail = "In Firestorm Citadel (Floor 1)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_F1;
                        largeImageDesc = "Blackstone Bridge";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F2:
                        detail = "In Firestorm Citadel (Floor 2)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_F2;
                        largeImageDesc = "Charred Court";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F3:
                        detail = "In Firestorm Citadel (Floor 3)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_F3;
                        largeImageDesc = "Ashen Armory";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F4:
                        detail = "In Firestorm Citadel (Floor 4)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_F4;
                        largeImageDesc = "Smoldering Steps";
                        break;
                    case IdentCodes.IDENT_FIRESTORM_CITADEL_F5:
                        detail = "In Firestorm Citadel (Boss Fight)";
                        largeImageKey = ImageCodes.IMAGE_FIRESTORM_CITADEL_BOSS;
                        largeImageDesc = "Throne Room";
                        break;
                    case IdentCodes.IDENT_OCH:
                        detail = "In Operation Crimson Hammer";
                        largeImageKey = ImageCodes.IMAGE_OCH;
                        largeImageDesc = "Operation Crimson Hammer";
                        break;
                    case IdentCodes.IDENT_THE_CORE:
                        detail = "In The Core Terminal";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "The Core";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES:
                        detail = "In Dreams and Nightmares";
                        largeImageKey = ImageCodes.IMAGE_THE_CORE;
                        largeImageDesc = "Dreams and Nightmares";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES_F3:
                        detail = "In Dreams and Nightmares (Floor 3)";
                        largeImageKey = ImageCodes.IMAGE_DREAMS_DESCENT;
                        largeImageDesc = "Descent into Darkness";
                        break;
                    case IdentCodes.IDENT_DREAMS_AND_NIGHTMARES_END:
                        detail = "In Dreams and Nightmares (End)";
                        largeImageKey = ImageCodes.IMAGE_DREAMS_REFUGE;
                        largeImageDesc = "Refuge";
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
                    case IdentCodes.IDENT_LOCKDOWN_02:
                        detail = "In Lockdown (Ruins)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_RUINS;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_04:
                        detail = "In Lockdown (Facility)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_FACILITY;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_07:
                        detail = "In Lockdown (Reactor)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_REACTOR;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_08:
                        detail = "In Lockdown (Forest)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_FOREST;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_10:
                        detail = "In Lockdown (Necropolis)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_NECROPOLIS;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_11:
                        detail = "In Lockdown (Furnace)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_FURNACE;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_12:
                        detail = "In Lockdown (Ramparts)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_RAMPARTS;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_13:
                        detail = "In Lockdown (Downtown)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_DOWNTOWN;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_14:
                        detail = "In Lockdown (Pipeline)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_PIPELINE;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_15:
                        detail = "In Lockdown (Icebox)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_ICEBOX;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_16:
                        detail = "In Lockdown (Frostbite)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_FROSTBITE;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_17:
                        detail = "In Lockdown (Stadium)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_STADIUM;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_18:
                        detail = "In Lockdown (Gardens)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_GARDENS;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_20:
                        detail = "In Lockdown (Mines)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_MINES;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_21:
                        detail = "In Lockdown (Avenue)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_AVENUE;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_LOCKDOWN_22:
                        detail = "In Lockdown (Fortress)";
                        largeImageKey = ImageCodes.IMAGE_LOCKDOWN_FORTRESS;
                        largeImageDesc = "Lockdown";
                        break;
                    case IdentCodes.IDENT_BLAST_01:
                        detail = "In Blast Network (Gridlock)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_GRIDLOCK;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_02:
                        detail = "In Blast Network (Rockets)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_ROCKETS;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_03:
                        detail = "In Blast Network (Gridlock 2)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_GRIDLOCK2;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_04:
                        detail = "In Blast Network (Rockets 2)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_ROCKETS2;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_05:
                        detail = "In Blast Network (Two-Tone)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_TWOTONE;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_06:
                        detail = "In Blast Network (Division)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_DIVISION;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_07:
                        detail = "In Blast Network (Stone Cross)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_STONECROSS;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_08:
                        detail = "In Blast Network (Spikes)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_SPIKES;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_09:
                        detail = "In Blast Network (Ring)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_RING;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_10:
                        detail = "In Blast Network (Crystals)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_CRYSTALS;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_11:
                        detail = "In Blast Network (Islands)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_ISLANDS;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_12:
                        detail = "In Blast Network (Backdoor)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_BACKDOOR;
                        largeImageDesc = "Blast Network";
                        break;
                    case IdentCodes.IDENT_BLAST_13:
                        detail = "In Blast Network (Crystals 2)";
                        largeImageKey = ImageCodes.IMAGE_BLAST_CRYSTALS2;
                        largeImageDesc = "Blast Network";
                        break;
                    default:
                        return;
                }
                set(detail, largeImageKey, largeImageDesc);
                AppWindow.currentWhereabouts = whereabouts;
            }
        }
    }
}
