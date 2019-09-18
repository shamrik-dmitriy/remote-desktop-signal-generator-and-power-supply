﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Exchange.LanExchange;

namespace Core.Devices.N5746A
{
    /// <summary>
    ///     Agilent N5746A Power Supply Class
    /// </summary>
    public sealed class N5746A
    {
        #region Private Member Variables

        /// <summary>
        ///     LAN class instance
        /// </summary>
        private readonly DeviceExchanger _deviceExchanger;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor Agilent N5746A
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <param name="ipPort">Device port</param>
        public N5746A(string ipAddress, int ipPort)
        {
            try
            {
                ApplicationModel.Logger.Debug("Initializing LAN Power Supply exchange");
                _deviceExchanger = new DeviceExchanger(ipAddress, ipPort);
                ApplicationModel.Logger.Debug("LAN exchange with power supply initialized");
            }
            catch (Exception n5746AException)
            {
                throw new N5746AException("Failed to initialize LAN exchange for power supply: " +
                                          n5746AException.Message + "\n");
            }
        }

        #endregion

        #region Public Methods

        #region Identification, Power On/Off, Reset, Test

        /// <summary>
        ///     Get ОРС
        /// </summary>
        /// <returns>True - OPC Complete, False - OPC Not complete</returns>
        public bool Opc()
        {
            try
            {
                return _deviceExchanger.SendRequestDataInt("*OPC?;") == 1;
            }
            catch (N5746AException n5746AException)
            {
                ApplicationModel.Logger.Error(": " + n5746AException.Message);
                throw new N5746AException(": " + n5746AException.Message);
            }
        }

        /// <summary>
        ///     Device identification
        /// </summary>
        /// <returns>Device Identifier String</returns>
        public string Identification()
        {
            try
            {
                var result = _deviceExchanger.SendRequestDataString("*IDN?;");
                return result;
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to identify power source: " + n5746AException.Message);
            }
        }

        /// <summary>
        ///     Resets power supply
        /// </summary>
        public void Reset()
        {
            try
            {
                ApplicationModel.Logger.Debug("Reset power supply");
                _deviceExchanger.SendRequestDataString("RST;");
                ApplicationModel.Logger.Debug("Power supply reset");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to reset the parameter to the power source of the power source: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Returns current output status of power supply
        /// </summary>
        /// <returns>True - On, false - Off</returns>
        public bool GetOutputState()
        {
            try
            {
                ApplicationModel.Logger.Debug("Checking the status of the power supply output");
                return _deviceExchanger.SendRequestDataInt(":OUTP:STAT?;") == 1;
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to check the status of the power supply output: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Power supply output turn on
        /// </summary>
        public void OutputStateOn()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turning on the power supply output");
                _deviceExchanger.SendRequestDataString("OUTP:STAT ON;");
                ApplicationModel.Logger.Debug("Power supply output is on");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to enable power supply output: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Power supply output turn off
        /// </summary>
        public void OutputStateOff()
        {
            try
            {
                ApplicationModel.Logger.Debug("Turning off the power supply output");
                _deviceExchanger.SendRequestDataString("OUTP:STAT OFF;");
                ApplicationModel.Logger.Debug("Power supply output is off");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to turn off power supply output: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Test devices
        /// </summary>
        /// <returns>Result string</returns>
        public string Test()
        {
            try
            {
                ApplicationModel.Logger.Debug("Power Supply Testing");
                return _deviceExchanger.SendRequestDataString("*TST?;");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to test power supply: " +
                                          n5746AException.Message);
            }
        }

        #endregion

        #region Set Parametrs

        /// <summary>
        ///     Sets the voltage value in V indicated by the parameter
        /// </summary>
        /// <param name="voltage">Source voltage value</param>
        public void SetSupplyVoltage(string voltage)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the supply voltage " + voltage + "V");
                _deviceExchanger.SendRequestDataString("VOLT " + voltage.Replace(",", ".") + ";");
                ApplicationModel.Logger.Debug("Supply voltage " + voltage + "V is set");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to set supply voltage " + voltage + "V: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Sets the voltage value in V indicated by the parameter
        /// </summary>
        /// <param name="voltage">Source voltage value</param>
        public void SetSupplyVoltage(double voltage)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the supply voltage " + voltage + "V");

                _deviceExchanger.SendDataWithOutReturn(
                    "VOLT " + Convert.ToString(voltage, CultureInfo.CurrentCulture).Replace(",", ".") +
                    ";");
                ApplicationModel.Logger.Debug("Supply voltage " + voltage + "V is set");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to set supply voltage " + voltage + "V: " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Sets over-voltage level protection
        /// </summary>
        /// <param name="lvl">Protection Level Value</param>
        public void SetVoltageProtectionLvl(int lvl)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the level of protection against overload " + lvl);
                _deviceExchanger.SendRequestDataString("VOLT:PROT:LEV " + lvl + ";");
                ApplicationModel.Logger.Debug("Overload protection level set to " + lvl);
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to set overload protection level to " + lvl + ": " +
                                          n5746AException.Message);
            }
        }

        /// <summary>
        ///     Sets the current limit value, with parameter type
        /// </summary>
        /// <param name="limit">Maximum current consumption</param>
        public void SetLowVoltageLim(string limit)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the maximum current consumption to " + limit + "А");
                _deviceExchanger.SendRequestDataString("CURR:LEV " + limit.Replace(",", ".") + ";");
                ApplicationModel.Logger.Debug("The maximum current consumption is set to " + limit + "А");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException(
                    "Failed to set maximum consumption current to " +
                    limit + "А: " + n5746AException.Message);
            }
        }

        /// <summary>
        ///     Sets the current limit value
        /// </summary>
        /// <param name="limit">Maximum current consumption</param>
        public void SetLowVoltageLim(double limit)
        {
            try
            {
                ApplicationModel.Logger.Debug("Setting the maximum current consumption to " + limit + "А");
                _deviceExchanger.SendRequestDataString("CURR:LEV " +
                                                       Convert.ToString(limit, CultureInfo.CurrentCulture)
                                                           .Replace(",", ".") + ";");
                ApplicationModel.Logger.Debug("The maximum current consumption is set to " + limit + "А");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException(
                    "Failed to set maximum consumption current to " +
                    limit + "А: " + n5746AException.Message);
            }
        }

        #endregion

        #region Get Parametrs

        /// <summary>
        ///     Return OPC
        /// </summary>
        /// <returns>True - Complete, False - Uncomplete</returns>
        public bool GetOpc()
        {
            try
            {
                ApplicationModel.Logger.Debug("Power Supply Availability Request");

                return _deviceExchanger.SendRequestDataInt("*OPC?;") == 1;
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("OPC request failed: " + n5746AException.Message);
            }
        }

        /// <summary>
        ///     Returns the current measured consumed value of the current consumption through the power circuit "+ 28V"
        /// </summary>
        /// <returns>Current measured current value</returns>
        public double GetCurrent()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for current measured value of current consumption");
                return _deviceExchanger.SendRequestDataDouble("MEAS:CURR?;");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException(
                    "Failed to fulfill the request for the current measured value of the current consumption: " +
                    n5746AException.Message);
            }
        }

        /// <summary>
        ///     Returns the current voltage
        /// </summary>
        /// <returns>Value of current voltage</returns>
        public double GetVoltage()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for the current measured voltage value");
                return _deviceExchanger.SendRequestDataDouble("MEAS:VOLTage?;");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException(
                    "Failed to complete the request for the current measured voltage value: " +
                    n5746AException.Message);
            }
        }

        /// <summary>
        ///     Returns current limit
        /// </summary>
        /// <returns>Value of current limit</returns>
        public double GetCurrentLimit()
        {
            try
            {
                ApplicationModel.Logger.Debug("Request for current current limit");
                return _deviceExchanger.SendRequestDataDouble("CURR:LEV?;");
            }
            catch (N5746AException n5746AException)
            {
                throw new N5746AException("Failed to fulfill the request for current limit: " +
                                          n5746AException.Message);
            }
        }

        #endregion

        #endregion
    }
}