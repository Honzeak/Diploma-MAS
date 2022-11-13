using System.Linq;

namespace ItsAgentFramework
{
    public abstract class Sequencer
    {
        private SkillList _skillList;

        public Sequencer(SkillList skillList)
        {
            _skillList = skillList;

            foreach (var skill in _skillList)
            {
                skill.SkillTerminated += HandleSkillTerminated;
            }
        }

        public virtual void InitSkills()
        {
            foreach (var skill in _skillList) 
            {
                skill.Initialize();
                // pattern matching
            }
        }

        protected virtual void HandleSkillTerminated(object sender, EventArgs e)
        {
            var skill = sender as Skill;
            //pattern matching
        }

        public virtual void ActivateTask(AgentTask task)
        {
            foreach( var skillType in task.Skills)
            {
                _skillList[skillType].Activate();
            }
        }
    }
}
