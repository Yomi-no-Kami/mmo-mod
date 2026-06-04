using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill
{
    public static class SkillExperience
    {
        public static void Award(Player player, global::Skills.SkillType skill, float amount)
        {
            if (player == null)
            {
                return;
            }

            player.RaiseSkill(skill, amount);
        }

        public static float GetLevel(Player player, global::Skills.SkillType skill)
        {
            if (player == null)
            {
                return 0f;
            }

            return player.GetSkillLevel(skill);
        }
    }
}