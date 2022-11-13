using ItsAgentFramework;

namespace ItsAgentFramework.UnitTests
{
    
    public class SkillListTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldGetSkillByType()
        {
            var sl = new SkillList();
            var newSkill = new TestSkill();
            sl.Add(newSkill);
            var acquiredSkill = sl[typeof(TestSkill)];
            Assert.That(acquiredSkill.GetType(), Is.EqualTo(typeof(TestSkill)));
        }

        [Test]
        public void ShouldThrowWhenAddingDupeSkillType()
        {
            var sl = new SkillList();
            var newSkill1 = new TestSkill();
            var newSkill2 = new TestSkill();
            sl.Add(newSkill1);
            Assert.Throws<ArgumentException>(() => sl.Add(newSkill2));
        }

        public class TestSkill : Skill
        {
            public TestSkill() : base()
        {
        }

        public override void Activate()
        {
            throw new NotImplementedException();
        }

        public override void Deactivate()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
}