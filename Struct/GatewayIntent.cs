using Discord;

namespace August.Struct
{
    /// <summary>
    /// Discord bot intent setting
    /// </summary>
    public static class GatewayIntentExtensions
    {
        public static int GetFlag(this GatewayIntent intents)
        {
            int flag = 0;
            if (intents.Guilds) flag = flag | (int)GatewayIntents.Guilds;
            if (intents.GuildMembers) flag = flag | (int)GatewayIntents.GuildMembers;
            if (intents.GuildBans) flag = flag | (int)GatewayIntents.GuildBans;
            if (intents.GuildEmojis) flag = flag | (int)GatewayIntents.GuildEmojis;
            if (intents.GuildIntegrations) flag = flag | (int)GatewayIntents.GuildIntegrations;
            if (intents.GuildWebhooks) flag = flag | (int)GatewayIntents.GuildWebhooks;
            if (intents.GuildInvites) flag = flag | (int)GatewayIntents.GuildInvites;
            if (intents.GuildVoiceStates) flag = flag | (int)GatewayIntents.GuildVoiceStates;
            if (intents.GuildPresences) flag = flag | (int)GatewayIntents.GuildPresences;
            if (intents.GuildMessages) flag = flag | (int)GatewayIntents.GuildMessages;
            if (intents.GuildMessageReactions) flag = flag | (int)GatewayIntents.GuildMessageReactions;
            if (intents.GuildMessageTyping) flag = flag | (int)GatewayIntents.GuildMessageTyping;
            if (intents.DirectMessages) flag = flag | (int)GatewayIntents.DirectMessages;
            if (intents.DirectMessageReactions) flag = flag | (int)GatewayIntents.DirectMessageReactions;
            if (intents.DirectMessageTyping) flag = flag | (int)GatewayIntents.DirectMessageTyping;
            if (intents.GuildScheduledEvents) flag = flag | (int)GatewayIntents.GuildScheduledEvents;
            if (intents.AllUnprivileged) flag = flag | (int)GatewayIntents.AllUnprivileged;
            if (intents.All) flag = flag | (int)GatewayIntents.All;
            return flag;
        }
    }
}
