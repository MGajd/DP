using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Machine
{
    public class MachineObject
    {
        private int _width;
        private int _speed;
        private int _turningRadius;

        /// <summary>
        /// Distance that can be traveled by machine due to energy source (i.e. fuel).
        /// </summary>
        private int _energySourceLimitation = -1;

        /// <summary>
        /// Distance that can be traveled by machine due to stack source (carriage space).
        /// </summary>
        private int _spaceLimitaion = -1;

        /// <summary>
        /// Domain specific informations.
        /// </summary>
        private List<object> _domainSpecifics;

        /// <summary>
        /// Domain specific limitations.
        /// </summary>
        private List<object> _domainLimitations;


        public MachineObject() { }
    }
}
