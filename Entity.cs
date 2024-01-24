using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_CalebWolthers_22012024
{
    internal class Entity : GameObjects
    {

        public HealthSystem healthSystem;

        public Entity()
        {
            healthSystem = new HealthSystem();
        }

    }
}
