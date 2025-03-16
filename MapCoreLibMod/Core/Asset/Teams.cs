using System.Collections.Generic;
using System.IO;

namespace MapCoreLib.Core.Asset
{
    public class Teams: MajorAsset
    {
        public List<Team> teamList = new List<Team>();
        
        public HashSet<string> teamNameSet = new HashSet<string>();

        protected override void parseData(BinaryReader binaryReader, MapDataContext context)
        {
            var count = binaryReader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                teamList.Add(new Team().fromStream(binaryReader, context));
            }
        }

        protected override void saveData(BinaryWriter binaryWriter, MapDataContext context)
        {
            binaryWriter.Write(teamList.Count);
            foreach (var team in teamList)
            {
                team.saveData(binaryWriter, context);
            }
        }

        public override string getAssetName()
        {
            return Ra3MapConst.ASSET_Teams;
        }

        public override short getVersion()
        {
            return 1;
        }

        public Team addTeam(MapDataContext context, string teamName, string belongToPlayerName)
        {
            if (teamNameSet.Contains(teamName))
            {
                throw new Exception("Team already exists: " + teamName);
            }
            
            var team = Team.of(context, teamName, belongToPlayerName);
            teamList.Add(team);
            teamNameSet.Add(teamName);
            return team;
        }

        public bool removeTeam(MapDataContext context, string teamName)
        {
            if (!teamNameSet.Contains(teamName))
            {
                return false;
            }

            teamNameSet.Remove(teamName);
            
            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i].propertyCollection.getProperty("teamOwner").data.ToString() == teamName)
                {
                    teamList.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public static Teams newInstance(MapDataContext context)
        {
            var teams = new Teams();
            teams.name = Ra3MapConst.ASSET_Teams;
            teams.id = context.MapStruct.RegisterString(teams.name);
            teams.version = teams.getVersion();

            teams.addTeam(context, "team", "");
            teams.addTeam(context, "teamPlayer_1", "Player_1");
            teams.addTeam(context, "teamPlayer_2", "Player_2");
            teams.addTeam(context, "teamPlayer_3", "Player_3");
            teams.addTeam(context, "teamPlayer_4", "Player_4");
            teams.addTeam(context, "teamPlayer_5", "Player_5");
            teams.addTeam(context, "teamPlayer_6", "Player_6");
            teams.addTeam(context, "teamPlyrCivilian", "PlyrCivilian");
            teams.addTeam(context, "teamPlyrCreeps", "PlyrCreeps");
            teams.addTeam(context, "teamPlyrNeutral", "PlyrNeutral");
            teams.addTeam(context, "teamSkirmishCivilian", "SkirmishCivilian");
            teams.addTeam(context, "teamSkirmishRandom", "SkirmishRandom");
            teams.addTeam(context, "teamSkirmishSoviet", "SkirmishSoviet");
            teams.addTeam(context, "teamSkirmishAllies", "SkirmishAllies");
            teams.addTeam(context, "teamSkirmishJapan", "SkirmishJapan");
            teams.addTeam(context, "teamSkirmishObserver", "SkirmishObserver");
            teams.addTeam(context, "teamSkirmishNull", "SkirmishNull");
            
            // teams.teamList.Add(Team.of(context, "team", ""));
            // teams.teamList.Add(Team.of(context, "teamPlayer_1", "Player_1"));
            // teams.teamList.Add(Team.of(context, "teamPlayer_2", "Player_2"));
            // teams.teamList.Add(Team.of(context, "teamPlayer_3", "Player_3"));
            // teams.teamList.Add(Team.of(context, "teamPlayer_4", "Player_4"));
            // teams.teamList.Add(Team.of(context, "teamPlayer_5", "Player_5"));
            // teams.teamList.Add(Team.of(context, "teamPlayer_6", "Player_6"));
            // teams.teamList.Add(Team.of(context, "teamPlyrCivilian", "PlyrCivilian"));
            // teams.teamList.Add(Team.of(context, "teamPlyrCreeps", "PlyrCreeps"));
            // teams.teamList.Add(Team.of(context, "teamPlyrNeutral", "PlyrNeutral"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishCivilian", "SkirmishCivilian"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishRandom", "SkirmishRandom"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishSoviet", "SkirmishSoviet"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishAllies", "SkirmishAllies"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishJapan", "SkirmishJapan"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishObserver", "SkirmishObserver"));
            // teams.teamList.Add(Team.of(context, "teamSkirmishNull", "SkirmishNull"));
            return teams;
        }
    }
}