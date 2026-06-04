using Jotunn.Utils;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.slayer
{
    public class SlayerSkill : AbstractScapeSkill
    {
        public static SlayerSkill Instance;

        public static global::Skills.SkillType Type;

        public SlayerSkill()
        {
            Instance = this;
        }

        public override string Identifier =>
            "com.scapeheim.skill.slayer";

        public override string Name =>
            "Slayer";

        public override string Description =>
            "Unlock the ability to kill stronger creatures and bosses. Kill any creatures/bosses to gain slayer xp passively.";
        public override Sprite Icon => AssetUtils.LoadSpriteFromFile("ScapeHeimModStub/Assets/Sprites/SkillIcons/SLAYER.png");

        public override float IncreaseStep =>
            1f;

        public override void Register()
        {
            base.Register();

            Type = SkillType;
        }
    }
}