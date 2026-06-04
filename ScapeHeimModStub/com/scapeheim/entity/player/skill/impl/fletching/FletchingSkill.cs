using Jotunn.Utils;
using ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.smithing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Skills;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill.impl.fletching
{
    public class FletchingSkill : AbstractScapeSkill
    {
        public static FletchingSkill Instance;

        public static global::Skills.SkillType Type;

        public FletchingSkill()
        {
            Instance = this;
        }

        public override string Identifier =>
            "com.scapeheim.skill.fletching";

        public override string Name =>
            "Fletching";

        public override string Description =>
            "Unlock the ability to craft stronger arrows. Gain xp by crafting arrows.";

        public override Sprite Icon => AssetUtils.LoadSpriteFromFile("ScapeHeimModStub/Assets/Sprites/SkillIcons/FLETCHING.png");

        public override float IncreaseStep =>
            1f;

        public override void Register()
        {
            base.Register();

            Type = SkillType;
        }
    }
}
