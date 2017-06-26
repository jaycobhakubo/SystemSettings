using System;
using System.Collections.Generic;
using System.Text;
using GTI.Modules.Shared;
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;

namespace GTI.Modules.SystemSettings.Business
{
    public class DistributorFeesModel
    {
        private List<DistributorFee> m_distributorFeesList;

        public DistributorFeesModel()
        {
            DistributorFeesList = new List<DistributorFee>();
        }

        //load model
        public bool LoadDistributorFeesFromDatabase()
        {
            m_distributorFeesList.Clear();
            GetDistributorFeesMessage message = new GetDistributorFeesMessage(Common.OperatorId);
            message.Send();
            m_distributorFeesList = message.DistributorFeeList;

            return true;
        }

        //save model
        public bool SaveDistributorFeeToDatabase(int deviceID)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceID);
            if (fee != null)
            {
                SetDistributorFees message = new SetDistributorFees(fee);
                message.Send();
                
                if (message.ServerReturnCode == GTIServerReturnCode.Success)
                {
                    fee = message.DistributorFee;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public List<DistributorFee> DistributorFeesList
        {
            get { return m_distributorFeesList; }
            set { m_distributorFeesList = value; }
        }

        internal bool Add(DistributorFeeDataItem fee,int deviceType,int feeType)
        {
            DistributorFee feeToUpdate = m_distributorFeesList.Find(i => i.DeviceId == deviceType);

            if (feeToUpdate == null)
            {
                DistributorFee newFee = new DistributorFee();
                newFee.DeviceId = deviceType;
                newFee.OperatorId = Common.OperatorId;
                newFee.DeviceFeeTypeId = feeType;
                newFee.DistributorFeeData = new List<DistributorFeeDataItem>();
                newFee.DistributorFeeData.Add(fee);
                m_distributorFeesList.Add(newFee);
            }

            else
            {
                feeToUpdate.DistributorFeeData.Add(fee);
            }
            return true;
        }

        public void Reset()
        {
            m_distributorFeesList.Clear();
            LoadDistributorFeesFromDatabase();
        }

        public DistributorFee GetDistributorById(int id)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => id == i.DeviceId);
            return fee;
        }

        public DistributorFee UpdateDistributorFee(DistributorFeeDataItem fee,int deviceType,int feeType,int tierLevel)
        {
            DistributorFee feeToUpdate = m_distributorFeesList.Find(i => i.DeviceId == deviceType);
            
            if(feeToUpdate == null)
            {
                DistributorFee newFee = new DistributorFee();
                newFee.DeviceId = deviceType;
                newFee.OperatorId = Common.OperatorId;
                newFee.DeviceFeeTypeId = feeType;
                newFee.DistributorFeeData = new List<DistributorFeeDataItem>();
                newFee.DistributorFeeData.Add(fee);
                m_distributorFeesList.Add(newFee);
                return newFee;
            }

            else
            {
                feeToUpdate.DeviceFeeTypeId = feeType;

                DistributorFeeDataItem dataItem = null;
                if(fee.DistributorFeeId != 0)
                {
                    dataItem = feeToUpdate.DistributorFeeData.Find(i => i.DistributorFeeId == fee.DistributorFeeId);
                }
                else if(tierLevel > 0 && feeToUpdate.DistributorFeeData.Count >= tierLevel)
                {
                    dataItem = feeToUpdate.DistributorFeeData[tierLevel - 1];
                }
                //Checks if the updated fee is an inventory based fee with a monthly/weekly/daily frequency
                else if ((feeToUpdate.DeviceFeeTypeId == 2 || feeToUpdate.DeviceFeeTypeId == 3 || feeToUpdate.DeviceFeeTypeId == 4) && feeToUpdate.DistributorFeeData.Count >= 1)
                {
                    dataItem = feeToUpdate.DistributorFeeData[0];
                }
                
                if(dataItem != null)
                {
                    dataItem.DistributorFee = fee.DistributorFee;
                    dataItem.FeeType = feeType;
                    dataItem.MinRange = fee.MinRange;
                }
                else
                {
                    feeToUpdate.DistributorFeeData.Add(fee);
                }
                
                if(feeToUpdate.DeviceFeeTypeId == 1)
                {
                    feeToUpdate = ReconcileFee(feeToUpdate);
                }
               
                return feeToUpdate;
            }
        }

        public DistributorFeeDataItem GetLastDistributorFee(int deviceId, int typeId = 0)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            int distributorFeeDataCount = 0;
            if(fee != null)
            {
                distributorFeeDataCount = fee.DistributorFeeData.Count;
            }
            //create a new fee for inventory type purposes
            //min and max range = 0
            if(fee == null || distributorFeeDataCount == 0)
            {
                DistributorFeeDataItem newItem = new DistributorFeeDataItem();
                newItem.DistributorFeeId = 0;
                newItem.MinRange = 0;
                newItem.MaxRange = 0;
                newItem.DistributorFee = 0;
                newItem.FeeType = typeId;
                
                return newItem;
            }
            else if (typeId != 0)
            {
                DistributorFeeDataItem item = fee.DistributorFeeData.Find(i => i.FeeType == typeId);

                if (item == null)
                {
                    item = new DistributorFeeDataItem();
                    item.DistributorFeeId = 0;
                    item.MinRange = 0;
                    item.MaxRange = 0;
                    item.DistributorFee = 0;
                    item.FeeType = typeId;
                }
                
                return item;
            }
            else
            {
                DistributorFeeDataItem oldItem = fee.DistributorFeeData[distributorFeeDataCount - 1];
                oldItem.MaxRange = 0;
                oldItem.MinRange = 0;
                oldItem.DistributorFee = 0;
                return oldItem;
            }
        }

        internal DistributorFeeDataItem GetFirstDistributorFee(int deviceId)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            int distributorFeeDataCount = 0;
            if (fee != null)
            {
                distributorFeeDataCount = fee.DistributorFeeData.Count;
            }
            if (fee == null || distributorFeeDataCount == 0)
            {
                DistributorFeeDataItem newItem = new DistributorFeeDataItem();
                newItem.DistributorFeeId = 0;
                newItem.MinRange = 1;
                newItem.MaxRange = 9999;
                newItem.DistributorFee = 0;
                return newItem;
            }
            else
            {
                DistributorFeeDataItem oldItem = fee.DistributorFeeData[distributorFeeDataCount - 1];
                oldItem.MinRange = 1;
                oldItem.MaxRange = 9999;
                oldItem.DistributorFee = 0;
                return oldItem;
            }
        }

        public DistributorFeeDataItem GetSelectedDistributorFee(int deviceId, int tierId)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            int distributorFeeDataCount = 0;
            if (fee != null)
            {
                distributorFeeDataCount = fee.DistributorFeeData.Count;
            }
            
            if (fee == null || distributorFeeDataCount == 0 || tierId > distributorFeeDataCount)
            {
                if(fee == null)
                {
                    DistributorFee distributorFee = new DistributorFee();
                    
                    //only for per use
                    distributorFee.DeviceFeeTypeId = 1;
                    distributorFee.DeviceId = deviceId;
                    fee = distributorFee;
                }
                DistributorFeeDataItem newItem = new DistributorFeeDataItem();
                newItem.DistributorFeeId = 0;
                newItem.MinRange = 1;
                newItem.MaxRange = 9999;
                newItem.DistributorFee = 0;
                fee.DistributorFeeData.Add(newItem);
                return newItem;
            }
            else
            {
       
                DistributorFeeDataItem oldItem = fee.DistributorFeeData[tierId - 1];
                
                return oldItem;
            }
        }

        internal int GetPreviousStartValue(int deviceId, int tierLevel)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            
            if(fee.DistributorFeeData.Count > 0 && tierLevel >= 2)
            {
                return fee.DistributorFeeData[tierLevel - 2].MinRange;
            }
            else
            {
                return 1;
            }
        }

        internal bool ClearFees(int deviceId)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            List<DistributorFeeDataItem> feeList = new List<DistributorFeeDataItem>();
            if(fee != null && fee.DistributorFeeData.Count > 0)
            {
                RemoveDistributorFeesMessage message = new RemoveDistributorFeesMessage(fee.DistributorFeeData);
                message.Send();
                
                if(message.ServerReturnCode != GTIServerReturnCode.Success)
                {
                    return false;
                }

                else
                {
                    fee.DistributorFeeData.Clear();
                }
            }

            return true;
        }

        internal DistributorFee RemoveTier(int deviceId, int tierId)
        {
            DistributorFee fee = m_distributorFeesList.Find(i => i.DeviceId == deviceId);
            
            if(fee != null && tierId <= fee.DistributorFeeData.Count)
            {
                DistributorFeeDataItem item = fee.DistributorFeeData[tierId - 1];
                List<DistributorFeeDataItem> feeList = new List<DistributorFeeDataItem>();
                feeList.Add(item);
                RemoveDistributorFeesMessage message = new RemoveDistributorFeesMessage(feeList);
                message.Send();
                if(message.ServerReturnCode == GTIServerReturnCode.Success)
                {
                    fee.DistributorFeeData.Remove(item);
                    
                }
            }

            fee = ReconcileFee(fee);
            SaveDistributorFeeToDatabase(deviceId);
            return fee;
        }

        private DistributorFee ReconcileFee(DistributorFee fee)
        {
            if(fee.DistributorFeeData.Count == 0)
            {
                m_distributorFeesList.Remove(fee);
                fee = null;
            }

            else
            {
                for(int i=0;i<fee.DistributorFeeData.Count;i++)
                {
                    if(i==0)
                    {
                        fee.DistributorFeeData[i].MinRange = 1;
                    }
                    else if(i>0)
                    {
                        //if previous start value is greater than change this start value
                        if(fee.DistributorFeeData[i-1].MinRange > fee.DistributorFeeData[i].MinRange)
                        {
                            fee.DistributorFeeData[i].MinRange = fee.DistributorFeeData[i - 1].MinRange + 1;
                        }
                        //previous end value equals this fees start value minus one
                        fee.DistributorFeeData[i - 1].MaxRange = fee.DistributorFeeData[i].MinRange - 1;
                    }
                }
                fee.DistributorFeeData[fee.DistributorFeeData.Count - 1].MaxRange = 9999;
                
            }
            return fee;
        }
    }

}
