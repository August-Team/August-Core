using Discord;
using System;

namespace August.Struct
{
    [Serializable]
    public struct GatewayIntent
    {
        public bool Guilds;
        public bool GuildMembers;
        public bool GuildBans;
        public bool GuildEmojis;
        public bool GuildIntegrations;
        public bool GuildWebhooks;
        public bool GuildInvites;
        public bool GuildVoiceStates;
        public bool GuildPresences;
        public bool GuildMessages;
        public bool GuildMessageReactions;
        public bool GuildMessageTyping;
        public bool DirectMessages;
        public bool DirectMessageReactions;
        public bool DirectMessageTyping;
        public bool GuildScheduledEvents;
        public bool AllUnprivileged;
        public bool All;

        public int GetFlag()
        {
            int flag = 0;
            if (Guilds) flag = flag | (int)GatewayIntents.Guilds;
            if (GuildMembers) flag = flag | (int)GatewayIntents.GuildMembers;
            if (GuildBans) flag = flag | (int)GatewayIntents.GuildBans;
            if (GuildEmojis) flag = flag | (int)GatewayIntents.GuildEmojis;
            if (GuildIntegrations) flag = flag | (int)GatewayIntents.GuildIntegrations;
            if (GuildWebhooks) flag = flag | (int)GatewayIntents.GuildWebhooks;
            if (GuildInvites) flag = flag | (int)GatewayIntents.GuildInvites;
            if (GuildVoiceStates) flag = flag | (int)GatewayIntents.GuildVoiceStates;
            if (GuildPresences) flag = flag | (int)GatewayIntents.GuildPresences;
            if (GuildMessages) flag = flag | (int)GatewayIntents.GuildMessages;
            if (GuildMessageReactions) flag = flag | (int)GatewayIntents.GuildMessageReactions;
            if (GuildMessageTyping) flag = flag | (int)GatewayIntents.GuildMessageTyping;
            if (DirectMessages) flag = flag | (int)GatewayIntents.DirectMessages;
            if (DirectMessageReactions) flag = flag | (int)GatewayIntents.DirectMessageReactions;
            if (DirectMessageTyping) flag = flag | (int)GatewayIntents.DirectMessageTyping;
            if (GuildScheduledEvents) flag = flag | (int)GatewayIntents.GuildScheduledEvents;
            if (AllUnprivileged) flag = flag | (int)GatewayIntents.AllUnprivileged;
            if (All) flag = flag | (int)GatewayIntents.All;
            return flag;
        }
        public static GatewayIntent Default
        {
            get
            {
                return new GatewayIntent()
                {
                    Guilds = false,
                    GuildMembers = false,
                    GuildBans = false,
                    GuildEmojis = false,
                    GuildIntegrations = false,
                    GuildWebhooks = false,
                    GuildInvites = false,
                    GuildVoiceStates = false,
                    GuildPresences = false,
                    GuildMessages = false,
                    GuildMessageReactions = false,
                    GuildMessageTyping = false,
                    DirectMessages = false,
                    DirectMessageReactions = false,
                    DirectMessageTyping = false,
                    GuildScheduledEvents = false,
                    AllUnprivileged = true,
                    All = false
                };
            }
        }
    }

    [Serializable]
    public struct ExecutionSetting
    {
        public string[] Initilization;
        public string[] Update;
        public string[] Shutdown;

        public string[] GuildMemberJoin;
        public string[] GuildMemberLeft;
        public string[] MemberJoinedGuild;
        public string[] MemberLeftGuild;
        public string[] GuildInviteCreated;
        public string[] GuildInviteDelete;
        public string[] VoiceStateChanged;
    }

    [Serializable]
    public struct BotSetting
    {
        public string Name;
        public string Token;
        public char Syntax;
        public string Prefix;
        public int Color;
        public int Loglevel;
        public bool GatewayIntentWarning;
        public string[] LoadMods;
    }

    public class BotSettings
    {
        public GatewayIntent intent;
        public ExecutionSetting execute;
        public BotSetting setting;

        public string prefixPath;
    }
}
