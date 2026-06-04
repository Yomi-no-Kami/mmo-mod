using System.Collections.Generic;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill
{
    public static class SkillRegistry
    {
        private static readonly List<IScapeSkill> Skills = new();

        public static void Register(IScapeSkill skill)
        {
            skill.Register();
            Skills.Add(skill);
        }

        public static IEnumerable<IScapeSkill> GetAll()
        {
            return Skills;
        }
    }
}