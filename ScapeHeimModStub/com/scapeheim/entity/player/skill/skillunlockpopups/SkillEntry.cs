namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.skillunlockpopups
{
    public class SkillEntry
    {
        public string ItemId;
        public float XP;
        public int LevelReq;

        public SkillEntry(string itemId, float xp, int levelReq)
        {
            ItemId = itemId;
            XP = xp;
            LevelReq = levelReq;
        }
    }
}