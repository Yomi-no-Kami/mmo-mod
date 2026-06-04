using Jotunn.Utils;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.fletching;
using System;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing
{
    public class SmithingSkill : AbstractScapeSkill
    {
        public static SmithingSkill Instance;

        public static global::Skills.SkillType Type;

        public SmithingSkill()
        {
            Instance = this;
        }

        public override string Identifier =>
            "com.scapeheim.skill.smithing";

        public override string Name =>
            "Smithing";

        public override string Description =>
            "Unlock the ability to craft stronger metal products. Gain xp by smelting ore/smithing items";

        public override Sprite Icon => AssetUtils.LoadSpriteFromFile("ScapeHeimModStub/Assets/Sprites/SkillIcons/SMITHING.png");

        public override float IncreaseStep =>
            1f;

        public override void Register()
        {
            base.Register();

            Type = SkillType;
        }
    }
}