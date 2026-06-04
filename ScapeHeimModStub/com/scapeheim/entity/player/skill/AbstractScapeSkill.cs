using Jotunn.Managers;
using Jotunn.Configs;
using UnityEngine;

namespace ScapeHeimModStub.com.scapeheim.entity.player.skill
{
    public abstract class AbstractScapeSkill : IScapeSkill
    {
        public abstract string Identifier { get; }

        public abstract string Name { get; }

        public abstract string Description { get; }

        public virtual float IncreaseStep => 1f;

        public virtual Sprite Icon => null;

        public global::Skills.SkillType SkillType { get; set; }

        public virtual void Register()
        {
            SkillConfig config = new SkillConfig
            {
                Identifier = Identifier,
                Name = Name,
                Description = Description,
                Icon = Icon,
                IncreaseStep = IncreaseStep
            };

            SkillType = SkillManager.Instance.AddSkill(config);
        }
    }
}