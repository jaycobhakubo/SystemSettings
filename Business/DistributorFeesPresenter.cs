using System;
using System.Collections.Generic;
using System.Text;
using GTI.Modules.Shared.Business;
using GTI.Modules.SystemSettings.UI;

namespace GTI.Modules.SystemSettings.Business
{
    public class DistributorFeesPresenter
    {
        private DistributorFeesModel m_distributorFeesModel;
        private DistributorFeesSettings m_distributorFeesView;

        public DistributorFeesPresenter(DistributorFeesSettings view)
        {
            m_distributorFeesView = view;
            m_distributorFeesModel = new DistributorFeesModel();
        }

        public bool LoadSettings()
        {   
            bool result = m_distributorFeesModel.LoadDistributorFeesFromDatabase();

            if(result == false)
                return false;
            m_distributorFeesView.LoadDistributorFees(m_distributorFeesModel.DistributorFeesList);
            return true;
        }

        public bool SaveSettings(int deviceID)
        {
            //todo don't load the view again but only update the saved fee same with operator management
            bool result = m_distributorFeesModel.SaveDistributorFeeToDatabase(deviceID);
            if(result == true)
            {
                m_distributorFeesView.LoadDistributorFees(m_distributorFeesModel.DistributorFeesList);
                
            }
            return result;
        }

        public bool AddDistributorFees(DistributorFeeDataItem newFee,int deviceId,int feeType)
        {
            return m_distributorFeesModel.Add(newFee, deviceId, feeType);
        }

        public void DistributorFeeSelected(int distributorFeeID, int deviceId)
        {
            DistributorFee fee = m_distributorFeesModel.GetDistributorById(deviceId);
            //m_distributorFeesView.DisplayDistributorFeeAttributes(fee,distributorFeeID);
        }

        public void UpdateDistributorFee(DistributorFeeDataItem updateFee, int deviceType,int feeType, int tierLevel)
        {
            DistributorFee fee = m_distributorFeesModel.UpdateDistributorFee(updateFee, deviceType, feeType, tierLevel);
             m_distributorFeesView.UpdateViewDistributorFee(fee, deviceType, feeType);
        }

        public void Reset()
        {
            m_distributorFeesModel.Reset();
            m_distributorFeesView.LoadDistributorFees(m_distributorFeesModel.DistributorFeesList);
        }

        public DistributorFeeDataItem GetLastDistributorFee(int deviceId, int typeId = 0)
        {
            return m_distributorFeesModel.GetLastDistributorFee(deviceId, typeId);
        }

        public DistributorFeeDataItem GetFirstDistributorFee(int deviceId)
        {
            return m_distributorFeesModel.GetFirstDistributorFee(deviceId);
        }

        public DistributorFeeDataItem GetSelectedDistributorFee(int deviceId, int tierId)
        {
            return m_distributorFeesModel.GetSelectedDistributorFee(deviceId, tierId);
        }

        public int GetPreviousStartValue(int deviceId, int tierLevel)
        {
            return m_distributorFeesModel.GetPreviousStartValue(deviceId, tierLevel);
        }

        internal bool ClearFees(int deviceId)
        {
            return m_distributorFeesModel.ClearFees(deviceId);
        }

        internal void RemoveTier(int deviceId, int tierId)
        {
            DistributorFee fee =  m_distributorFeesModel.RemoveTier(deviceId, tierId);
            m_distributorFeesView.LoadTabPage(fee,deviceId);
           
        }
    }
}
