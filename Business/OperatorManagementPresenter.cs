using System;
using System.Collections.Generic;
using System.Text;
using GTI.Modules.SystemSettings.UI;

namespace GTI.Modules.SystemSettings.Business
{
    public class OperatorManagementPresenter
    {
        private OperatorManagementModel operatorModel;
        private OperatorManagement operatorManagementView;

        public OperatorManagementPresenter(OperatorManagement view)
        {
            operatorModel = new OperatorManagementModel();
            operatorManagementView = view;
        }

        public void LoadModel(int currentIndex)
        {
            operatorModel.loadFromDatabase();
            operatorManagementView.LoadOperatorList(operatorModel.BingoOperators,currentIndex);
        }

        public void SaveModel(int currentIndex)
        {
            operatorModel.saveToDatabase();
            operatorManagementView.LoadOperatorList(operatorModel.BingoOperators,currentIndex);
        }

        public void AddOperator(BingoOperator bingoOperator)
        {
            operatorModel.addOperator(bingoOperator);
        }

        public BingoOperator GetOperatorByID(int operatorID)
        {
            //if the operator is in the list return the operator
            //else return null
            return operatorModel.GetOperatorByID(operatorID.ToString());
        }

        internal void ChangeActiveState(ActivityState state,int currentIndex)
        {
            switch (state)
            {
                case(ActivityState.Active):
                    operatorManagementView.LoadOperatorList(operatorModel.GetOperatorsByActivity(true), currentIndex);
                    break;
                case (ActivityState.All):
                    operatorManagementView.LoadOperatorList(operatorModel.BingoOperators, currentIndex);
                    break;
                case (ActivityState.Inactive):
                    operatorManagementView.LoadOperatorList(operatorModel.GetOperatorsByActivity(false), currentIndex);
                    break;
                default:
                    break;
            }
        }

        internal void UpdateOperator(BingoOperator bingoOperator)
        {
            operatorModel.UpdateOperator(bingoOperator);
        }

        internal void OperatorSelected(string operatorID)
        {
            BingoOperator bingoOperator = operatorModel.GetOperatorByID(operatorID);
            operatorManagementView.SetOperatorDetails(bingoOperator);
        }

       

        internal void Reset(int currentIndex)
        {
            operatorModel.Reset();
            operatorManagementView.LoadOperatorList(operatorModel.BingoOperators,currentIndex);
        }
    }
    public enum ActivityState
    {
        All,
        Active,
        Inactive
    }
}
