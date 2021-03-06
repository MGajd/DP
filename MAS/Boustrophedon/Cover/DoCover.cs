﻿using Boustrophedon.AreaObjects;
using Boustrophedon.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boustrophedon.Cover
{
    public partial class CoverObject
    {

        CoverLine newLine;

        public CoverLine GetNewCoverLine(string oldCoverLineID, MachineObject machineObject)
        {
            _oldCoverLine = WorldToCover.World.GetCoverLineByID(oldCoverLineID);
            _machineObject = machineObject;

            if (_oldCoverLine.IsDivide)
            {

            }
            int coverDirectionCoefficient;
            if (WorldToCover.World.CoverDirection == Enumerations.CoverDirection.leftToRight)
                coverDirectionCoefficient = 1;
            else if (WorldToCover.World.CoverDirection == Enumerations.CoverDirection.rightToLeft)
                coverDirectionCoefficient = -1;
            else
                coverDirectionCoefficient = 0;

            //newLine = new CoverLine();

            if (_oldCoverLine.StartingCoordinates.Point.Y > _oldCoverLine.EndingCoordinates.Point.Y)
            {
                if (coverDirectionCoefficient == 1)
                {
                    UpToDownLeftToRight(_oldCoverLine, _machineObject);
                }
                else if (coverDirectionCoefficient == -1)
                {
                    UpToDownRightToLeft(_oldCoverLine, _machineObject);
                }
                else
                {
                    DownToUpBoth(_oldCoverLine, _machineObject);
                }
            }

            else
            {
                if (coverDirectionCoefficient == 1)
                {
                    DownToUpLeftToRight(_oldCoverLine, _machineObject);
                }
                else if (coverDirectionCoefficient == -1)
                {
                    DownToUpRightToLeft(_oldCoverLine, _machineObject);
                }
                else
                {
                    DownToUpBoth(_oldCoverLine, _machineObject);
                }
            }

            // World.

            //TODO:blocker - add newLine to List<CoveredSubArea>

            return newLine;
        }



        private void DownToUpLeftToRight(CoverLine _oldCoverLine, MachineObject _machineObject)
        {
            if (_oldCoverLine.IsDivide)
            {
                newLine = new CoverLine(_oldCoverLine, (int)MachineObject.WorkingWidth, 0);
            }
            else
                throw new NotImplementedException();
        }

        private void DownToUpRightToLeft(CoverLine _oldCoverLine, MachineObject _machineObject)
        {
            if (_oldCoverLine.IsDivide)
            {
                newLine = new CoverLine(_oldCoverLine, (int)MachineObject.WorkingWidth * -1, 0);
            }
            else
                throw new NotImplementedException();
        }

        private void UpToDownLeftToRight(CoverLine _oldCoverLine, MachineObject _machineObject)
        {
            if (_oldCoverLine.IsDivide)
            {
                newLine = new CoverLine(_oldCoverLine, (int)MachineObject.WorkingWidth * -1, 0);
            }
            else
                throw new NotImplementedException();
        }

        private void UpToDownRightToLeft(CoverLine _oldCoverLine, MachineObject _machineObject)
        {
            if (_oldCoverLine.IsDivide)
            {
                newLine = new CoverLine(_oldCoverLine, (int)MachineObject.WorkingWidth, 0);
            }
            else
                throw new NotImplementedException();
        }

        private void DownToUpBoth(CoverLine _oldCoverLine, MachineObject _machineObject)
        {
            throw new NotImplementedException();
        }
    }
}