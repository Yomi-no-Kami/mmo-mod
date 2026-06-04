using Jotunn.Utils;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.herblore
{
    public class HerbloreSkill : AbstractScapeSkill
    {
        public static HerbloreSkill Instance;

        public static global::Skills.SkillType Type;

        public HerbloreSkill()
        {
            Instance = this;
        }

        public override string Identifier =>
            "com.scapeheim.skill.herblore";

        public override string Name =>
            "Herblore";

        public override string Description =>
            "Unlock the ability to craft stronger potions. Gain xp by crafting potions and fermenting ingredients.";

        public override Sprite Icon => AssetUtils.LoadSpriteFromFile("ScapeHeimModStub/Assets/Sprites/SkillIcons/HERBLORE.png");

        public override float IncreaseStep =>
            1f;

        public override void Register()
        {
            base.Register();

            Type = SkillType;
        }
    }
}