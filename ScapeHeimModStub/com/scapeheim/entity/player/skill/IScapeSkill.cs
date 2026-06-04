namespace ScapeHeimModStub.com.scapeheim.entity.player.skill
{
    public interface IScapeSkill
    {
        string Identifier { get; }

        global::Skills.SkillType SkillType { get; set; }

        void Register();
    }
}