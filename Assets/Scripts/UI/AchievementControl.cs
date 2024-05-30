using System.Collections.Generic;

public class AchievementControl : AchievementsManager
{
    private Dictionary<string, bool> achievements = new Dictionary<string, bool>()
    {
        {"Ten enemies", false},
        {"Welcome to hell", false}
    };
    
    void Update()
    {
        if (StaticHolder.enemyDeath >= 10 && !achievements["Ten enemies"])
        {
            achievements["Ten enemies"] = true;
            AnimateAchievement("Killed ten enemies", "First ten");
        }

        if (StaticHolder.isExtremeMode && !achievements["Welcome to hell"])
        {
            achievements["Welcome to hell"] = true;
            AnimateAchievement("Go into extreme mode for the first time", "Welcome to hell");
        }
    }
}
