using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsAgentFramework
{
    public abstract class Skill
    {
        public bool IsActive { get; private set; }

        public event EventHandler<EventArgs>? SkillTerminated;
        // Test for event

        public virtual void Activate()
        {
            IsActive = true;
        }
        public virtual void Deactivate()
        {
            IsActive = false;
        }
        public abstract void Update();
        public abstract void Initialize();

        private void OnSkillEnded() {
            var eventos = SkillTerminated;
            eventos?.Invoke(this, EventArgs.Empty);
            Deactivate();
        }

        public override bool Equals(object? obj)
        {
            return (obj is not null) ? this.GetType()==obj.GetType() : false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
