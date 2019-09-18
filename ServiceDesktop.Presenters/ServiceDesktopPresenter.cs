﻿using System;
using Core.Devices.N5746A;
using Core.Devices.SMB100A;
using ServiceDesktop.Models.ApplicationModels.MainForm;
using ServiceDesktop.Services.MessageServices;
using ServiceDesktop.Views;
using ServiceDesktop.Views.DeviceInitialization;

namespace ServiceDesktop.Presenter
{
    public class ServiceDesktopPresenter
    {
        #region Private Properties

        /// <summary>
        ///     Instance of interface main form
        /// </summary>
        private IServiceDesktopMainForm ServiceDesktopMainForm { get; set; }

        /// <summary>
        ///     Instance of interface model
        /// </summary>
        private IServiceDesktopModel ServiceDesktopModel { get; set; }

        /// <summary>
        ///     Instance of interface message services
        /// </summary>
        private IMessageService MessageService { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Presenter of main form
        /// </summary>
        /// <param name="serviceDesktopMainForm">Instance of interface main form</param>
        /// <param name="serviceDesktopModel">Instance of interface model</param>
        /// <param name="messageService">Instance of interface message services</param>
        public ServiceDesktopPresenter(IServiceDesktopMainForm serviceDesktopMainForm,
            IServiceDesktopModel serviceDesktopModel, IMessageService messageService)
        {
            ServiceDesktopMainForm = serviceDesktopMainForm;
            ServiceDesktopModel = serviceDesktopModel;
            MessageService = messageService;

            SubscribeEvents();
        }

        #endregion

        #region Private Methods

        #region Control Subscribe Events

        /// <summary>
        ///     Subscribe of events
        /// </summary>
        private void SubscribeEvents()
        {
            ServiceDesktopMainForm.ShowingForm += ServiceDesktopMainForm_ShowingForm;
            ServiceDesktopMainForm.ClosingForm += ServiceDesktopMainFormOnClosingForm;

            ServiceDesktopMainForm.GetVoltage += ServiceDesktopMainFormOnGetVoltage;
            ServiceDesktopMainForm.GetAmperage += ServiceDesktopMainFormOnGetAmperage;
            ServiceDesktopMainForm.GetFrequency += ServiceDesktopMainFormOnGetFrequency;
            ServiceDesktopMainForm.GetPow += ServiceDesktopMainFormOnGetPow;
            ServiceDesktopMainForm.GetPulseWidth += ServiceDesktopMainFormOnGetPulseWidth;
            ServiceDesktopMainForm.GetPulsePeriod += ServiceDesktopMainFormOnGetPulsePeriod;
            ServiceDesktopMainForm.GetDeviation += ServiceDesktopMainFormOnGetDeviation;
            ServiceDesktopMainForm.GetPulseDelay += ServiceDesktopMainFormOnGetPulseDelay;

            ServiceDesktopMainForm.SelectFrequencySignalGenerator +=
                ServiceDesktopMainFormOnSelectFrequencySignalGenerator;
            ServiceDesktopMainForm.SelectPowSignalGenerator += ServiceDesktopMainFormOnSelectPowSignalGenerator;
            ServiceDesktopMainForm.SelectPulseWidthSignalGenerator +=
                ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator;
            ServiceDesktopMainForm.SelectPulsePeriodSignalGenerator +=
                ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator;
            ServiceDesktopMainForm.SelectDeviationSignalGenerator +=
                ServiceDesktopMainFormOnSelectDeviationSignalGenerator;
            ServiceDesktopMainForm.SelectPulseDelaySignalGenerator +=
                ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator;

            ServiceDesktopMainForm.GetPowerSupplyPowerControl += ServiceDesktopMainFormOnGetPowerSupplyPowerControl;
            ServiceDesktopMainForm.GetSignalGeneratorRfControl += ServiceDesktopMainFormOnGetSignalGeneratorRfControl;
            ServiceDesktopMainForm.GetSignalGeneratorModulationControl +=
                ServiceDesktopMainFormOnGetSignalGeneratorModulationControl;

            ServiceDesktopModel.GetDataPowerSupplyComplete += ServiceDesktopModelOnGetDataPowerSupplyComplete;
            ServiceDesktopModel.GetDataSignalGeneratorComplete += ServiceDesktopModelOnGetDataSignalGeneratorComplete;
            ServiceDesktopModel.GetStateConnectionSignalGenerator +=
                ServiceDesktopModelOnGetStateConnectionSignalGenerator;
            ServiceDesktopModel.GetStateConnectionPowerSupply += ServiceDesktopModelOnGetStateConnectionPowerSupply;
        }

        /// <summary>
        ///     Get connection state power supply
        /// </summary>
        /// <returns>True - power supply is connection, False - power supply is not connection</returns>
        private bool ServiceDesktopModelOnGetStateConnectionPowerSupply()
        {
            var deviceInit = new DevicesInitialization(DevicesInitialization.Devices.SignalGenerator);
            deviceInit.ShowDialog();
            return deviceInit.StatusSignalGenerator;
        }

        /// <summary>
        ///     Get connection state signal generator
        /// </summary>
        /// <returns>True - signal generator is connection, False - signal generator is not connection</returns>
        private bool ServiceDesktopModelOnGetStateConnectionSignalGenerator()
        {
            var deviceInit = new DevicesInitialization(DevicesInitialization.Devices.PowerSupply);
            deviceInit.ShowDialog();
            return deviceInit.StatusPowerSupply;
        }

        /// <summary>
        ///     Unsubscribe of events
        /// </summary>
        private void UnSubscribeEvents()
        {
            ServiceDesktopMainForm.ShowingForm -= ServiceDesktopMainForm_ShowingForm;
            ServiceDesktopMainForm.ClosingForm -= ServiceDesktopMainFormOnClosingForm;

            ServiceDesktopMainForm.GetVoltage -= ServiceDesktopMainFormOnGetVoltage;
            ServiceDesktopMainForm.GetAmperage -= ServiceDesktopMainFormOnGetAmperage;
            ServiceDesktopMainForm.GetFrequency -= ServiceDesktopMainFormOnGetFrequency;
            ServiceDesktopMainForm.GetPow -= ServiceDesktopMainFormOnGetPow;
            ServiceDesktopMainForm.GetPulseWidth -= ServiceDesktopMainFormOnGetPulseWidth;
            ServiceDesktopMainForm.GetPulsePeriod -= ServiceDesktopMainFormOnGetPulsePeriod;
            ServiceDesktopMainForm.GetDeviation -= ServiceDesktopMainFormOnGetDeviation;
            ServiceDesktopMainForm.GetPulseDelay -= ServiceDesktopMainFormOnGetPulseDelay;

            ServiceDesktopMainForm.SelectFrequencySignalGenerator -=
                ServiceDesktopMainFormOnSelectFrequencySignalGenerator;
            ServiceDesktopMainForm.SelectPowSignalGenerator -= ServiceDesktopMainFormOnSelectPowSignalGenerator;
            ServiceDesktopMainForm.SelectPulseWidthSignalGenerator -=
                ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator;
            ServiceDesktopMainForm.SelectPulsePeriodSignalGenerator -=
                ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator;
            ServiceDesktopMainForm.SelectDeviationSignalGenerator -=
                ServiceDesktopMainFormOnSelectDeviationSignalGenerator;
            ServiceDesktopMainForm.SelectPulseDelaySignalGenerator -=
                ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator;

            ServiceDesktopMainForm.GetPowerSupplyPowerControl -= ServiceDesktopMainFormOnGetPowerSupplyPowerControl;
            ServiceDesktopMainForm.GetSignalGeneratorRfControl -= ServiceDesktopMainFormOnGetSignalGeneratorRfControl;
            ServiceDesktopMainForm.GetSignalGeneratorModulationControl -=
                ServiceDesktopMainFormOnGetSignalGeneratorModulationControl;

            ServiceDesktopModel.GetDataPowerSupplyComplete -= ServiceDesktopModelOnGetDataPowerSupplyComplete;
            ServiceDesktopModel.GetDataSignalGeneratorComplete -= ServiceDesktopModelOnGetDataSignalGeneratorComplete;
        }

        #endregion

        #region Form Actions

        /// <summary>
        ///     Override event closing forms
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ServiceDesktopMainFormOnClosingForm(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ServiceDesktopModel.DestroyOutputThreadSignalGenerator();
                }
                catch (Smb100AException smb100AException)
                {
                    MessageService.ShowError(smb100AException.Message,
                        "Error to finalization work with signal generator");
                }

                try
                {
                    ServiceDesktopModel.DestroyOutputThreadPowerSupply();
                }
                catch (N5746AException n5746AException)
                {
                    MessageService.ShowError(n5746AException.Message,
                        "Error to finalization work power supply");
                }
            }
            catch (Exception exception)
            {
                MessageService.ShowError(exception.Message);
            }
        }

        /// <summary>
        ///     Override event shown form
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        private void ServiceDesktopMainForm_ShowingForm(object sender, System.EventArgs e)
        {
            ServiceDesktopMainForm.SetAllCombobox(0);
            try
            {
                try
                {
                    if (ServiceDesktopModel.GetStateSignalGenerator())
                    {
                        ServiceDesktopMainForm.SetEnabledGroupBoxSignalGenerator(true);
                        ServiceDesktopModel.CreateInstanceSignalGenerator();
                        ServiceDesktopModel.CreateOutputThreadSignalGenerator();
                    }
                    else
                    {
                        ServiceDesktopMainForm.SetEnabledGroupBoxSignalGenerator(false);
                    }
                }
                catch (Smb100AException smb100AException)
                {
                    MessageService.ShowError(smb100AException.Message,
                        "Error to work with signal generator");
                }

                try
                {
                    if (ServiceDesktopModel.GetStatePowerSupply())
                    {
                        ServiceDesktopMainForm.SetEnabledGroupBoxPowerSupply(true);
                        ServiceDesktopModel.CreateInstancePowerSupply();
                        ServiceDesktopModel.CreateOutputThreadPowerSupply();
                    }
                    else
                    {
                        ServiceDesktopMainForm.SetEnabledGroupBoxPowerSupply(false);
                    }
                }
                catch (N5746AException n5746AException)
                {
                    MessageService.ShowError(n5746AException.Message,
                        "Error to work with power supply");
                }
            }
            catch (Exception exception)
            {
                MessageService.ShowError(exception.Message);
            }
        }

        #endregion

        #region Signal Generator

        #region Events Form

        #region Buttons

        /// <summary>
        ///     Control RF output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ServiceDesktopMainFormOnGetSignalGeneratorRfControl(bool state)
        {
            ServiceDesktopModel.SetSignalGeneratorRfControl(state);
        }

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (turned on)</param>
        private void ServiceDesktopMainFormOnGetSignalGeneratorModulationControl(bool state)
        {
            ServiceDesktopModel.SetSignalGeneratorModulationControl(state);
        }

        /// <summary>
        ///     Processing set frequency
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetFrequency(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //     ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pow
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPow(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse width
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulseWidth(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse period
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulsePeriod(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set deviation
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetDeviation(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set pulse delay
        /// </summary>
        /// <param name="nameField">Name of field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector</param>
        private void ServiceDesktopMainFormOnGetPulseDelay(string nameField, string valueField, string valueSelector)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField, valueSelector))
            {
                ServiceDesktopModel.SendToDevice(
                    Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList.SignalGenerator, valueSelector);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        #endregion

        #region Comboboxes

        /// <summary>
        ///     Processing selection selector of frequency
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectFrequencySignalGenerator(Smb100A.Frequency selector)
        {
            ServiceDesktopModel.FrequencySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pow
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPowSignalGenerator(Smb100A.Pow selector)
        {
            ServiceDesktopModel.PowSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse width
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulseWidthSignalGenerator(Smb100A.PulseWidth selector)
        {
            ServiceDesktopModel.PulseWidthSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse delay
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulseDelaySignalGenerator(Smb100A.PulseDelay selector)
        {
            ServiceDesktopModel.PulseDelaySelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of deviation
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectDeviationSignalGenerator(Smb100A.Deviation selector)
        {
            ServiceDesktopModel.DeviationSelector = selector;
        }

        /// <summary>
        ///     Processing selection selector of pulse period
        /// </summary>
        /// <param name="selector">Value of selector</param>
        private void ServiceDesktopMainFormOnSelectPulsePeriodSignalGenerator(Smb100A.PulsePeriod selector)
        {
            ServiceDesktopModel.PulsePeriodSelector = selector;
        }

        #endregion

        #endregion

        #region Events on Model

        /// <summary>
        ///     Processing events of Model of complete data output for signal generator
        /// </summary>
        private void ServiceDesktopModelOnGetDataSignalGeneratorComplete()
        {
            ServiceDesktopMainForm.SetOutputData("FrequencyOutput", ServiceDesktopModel.OutputFrequency.ToString());
            ServiceDesktopMainForm.SetOutputData("PowOutput", ServiceDesktopModel.OutputPow.ToString());
            ServiceDesktopMainForm.SetOutputData("PulseWidthOutput", ServiceDesktopModel.OutputPulseWidth.ToString());
            ServiceDesktopMainForm.SetOutputData("PulsePeriodOutput", ServiceDesktopModel.OutputPulsePeriod.ToString());
            ServiceDesktopMainForm.SetOutputData("DeviationOutput",
                ServiceDesktopModel.OutputPulseDeviation.ToString());
            ServiceDesktopMainForm.SetOutputData("PulseDelayOutput", ServiceDesktopModel.OutputPulseDelay.ToString());

            ServiceDesktopMainForm.SetOutputData("OutControlSignalGeneratorRf", ServiceDesktopModel.OutputRfState);
            ServiceDesktopMainForm.SetOutputData("OutControlSignalGeneratorModulation",
                ServiceDesktopModel.OutputModulationState);
        }

        #endregion

        #endregion

        #region Power Supply

        #region Events Form

        #region Buttons

        /// <summary>
        ///     Control power output
        /// </summary>
        /// <param name="state">True - Turn on (Turned off), False - Turn off (Turned on)</param>
        private void ServiceDesktopMainFormOnGetPowerSupplyPowerControl(bool state)
        {
            ServiceDesktopModel.SetPowerSupplyPowerControl(state);
        }

        /// <summary>
        ///     Processing set maximal amperage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ServiceDesktopMainFormOnGetAmperage(string nameField, string valueField)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField))
            {
                ServiceDesktopModel.SendToDevice(Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        /// <summary>
        ///     Processing set voltage
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        private void ServiceDesktopMainFormOnGetVoltage(string nameField, string valueField)
        {
            if (ServiceDesktopModel.Validate(nameField, valueField))
            {
                ServiceDesktopModel.SendToDevice(Models.ApplicationModels.MainForm.ServiceDesktopModel.DeviceList
                    .PowerSupply);
            }
            else
            {
                //        ServiceDesktopMainForm.SetErrorField(nameField);
            }
        }

        #endregion

        #endregion

        #region Events on Model

        /// <summary>
        ///     Processing events of Model of complete data output for power supply
        /// </summary>
        private void ServiceDesktopModelOnGetDataPowerSupplyComplete()
        {
            ServiceDesktopMainForm.SetOutputData("VoltageConstAmperageOutput",
                ServiceDesktopModel.OutputVoltage.ToString());
            ServiceDesktopMainForm.SetOutputData("AmperageOutput", ServiceDesktopModel.OutputAmperage.ToString());
            ServiceDesktopMainForm.SetOutputData("MaxAmperageConsumptionOutput",
                ServiceDesktopModel.OutputMaxAmperage.ToString());
            ServiceDesktopMainForm.SetOutputData("OutControlPowerSupply",
                ServiceDesktopModel.OutputOutState);
        }

        #endregion

        #endregion

        #endregion
    }
}