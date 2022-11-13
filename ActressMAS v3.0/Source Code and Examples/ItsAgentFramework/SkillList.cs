using System.Collections;

namespace ItsAgentFramework
{
    public class SkillList : IEnumerable<Skill>
    {
        private Dictionary<Type,Skill> _skillDict = new();

        public SkillList() { }

        public SkillList(IEnumerable<Skill> skillEnum)
        {
            foreach (var skill in skillEnum.Distinct())
            {
                _skillDict[skill.GetType()] = skill;
            }
        }

        public Skill this[Type skillType]
        {
            get { return _skillDict[skillType]; }
        }

        public void Add(Skill skill)
        {
            var skillType = skill.GetType();
            if( _skillDict.ContainsKey(skillType)) 
            {
                throw new ArgumentException("Tried to add skill type that is already present. " +
               "Consider removing the previous skill first");
            }
            _skillDict[skillType] = skill;
            return;
        }

        public void Remove(Skill skill)
        {
            var skillType = skill.GetType();
            if( !_skillDict.ContainsKey(skillType))
            {
                throw new ArgumentException("Tried to remove skill type that is not there.");
            }
            _skillDict.Remove(skillType);
            return;
        }

        public IEnumerator<Skill> GetEnumerator()
        {
            return _skillDict.Select(x => x.Value).ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
