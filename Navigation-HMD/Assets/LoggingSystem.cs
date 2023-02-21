/*
 * LoggingSystem.cs
 *
 * Project: Log2CSV - Simple Logging System for Unity applications
 *
 * Supported Unity version: 5.4.1f1 Personal (tested)
 *
 * Author: Nico Reski
 * Web: http://reski.nicoversity.com
 * Twitter: @nicoversity
 */

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Android;

public class LoggingSystem : MonoBehaviour {

	#region FIELDS

	// static log file names and formatters
	private static string LOGFILE_DIRECTORY = "log2csv_logfiles";
	private static string LOGFILE_NAME_BASE = "_log_file.csv";
	private static string LOGFILE_NAME_TIME_FORMAT = "yyyy-MM-dd_HH-mm-ss";	// prefix of the logfile, created when application starts (year - month - day - hour - minute - second)


	// logfile reference of the current session
	private string logFileHMD;
	private string logFilePhone;
	private TextWriter twMap; 
	private TextWriter _twHMD; 

	// bool representing whether the logging system should be used or not (set in the Unity Inspector)
	public bool activeLogging;

	#endregion



	#region START_UPDATE

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {

		if(this.activeLogging)
		{
			var permissions = new string[] { Permission.ExternalStorageRead,Permission.ExternalStorageWrite };
            Permission.RequestUserPermissions(permissions);
			Debug.Log(Application.persistentDataPath);
			
			// check if directory exists (and create it if not)
			if(!Directory.Exists(Application.persistentDataPath+LOGFILE_DIRECTORY)) Directory.CreateDirectory(Application.persistentDataPath+LOGFILE_DIRECTORY);

			// create file for this session using time prefix based on standard UTC time
			this.logFileHMD = Application.persistentDataPath+LOGFILE_DIRECTORY
				+ "/"
				+ System.DateTime.UtcNow.ToString(LOGFILE_NAME_TIME_FORMAT)
				//+ System.DateTime.UtcNow.AddHours(2.0).ToString(LOGFILE_NAME_TIME_FORMAT)	// manually adjust time zone, e.g. + 2 UTC hours for summer time in location Stockholm/Sweden
				+"_hmdData"
				+ LOGFILE_NAME_BASE;
			this.logFilePhone = Application.persistentDataPath+LOGFILE_DIRECTORY
				+ "/"
				+ System.DateTime.UtcNow.ToString(LOGFILE_NAME_TIME_FORMAT)
				//+ System.DateTime.UtcNow.AddHours(2.0).ToString(LOGFILE_NAME_TIME_FORMAT)	// manually adjust time zone, e.g. + 2 UTC hours for summer time in location Stockholm/Sweden
				+"_phoneData"
				+ LOGFILE_NAME_BASE;
			File.Create(this.logFileHMD).Dispose();
			File.Create(this.logFilePhone).Dispose();


			if(File.Exists(this.logFileHMD)) Debug.Log("[LoggingSystem] LogFile created at " + this.logFileHMD);
			else Debug.LogError("[LoggingSystem] Error creating LogFile");
			if(File.Exists(this.logFilePhone)) Debug.Log("[LoggingSystem] LogFile created at " + this.logFilePhone);
			else Debug.LogError("[LoggingSystem] Error creating LogFile");
		}
	}

	#endregion



	#region WRITE_TO_LOG

	/// <summary>
	/// Writes the message to the log file on disk.
	/// </summary>
	/// <param name="message">string representing the message to be written.</param>
	public void writeMessageToLog(string message)
	{
		if(this.activeLogging)
		{
			if(File.Exists(this.logFileHMD))
			{
				TextWriter tw = new StreamWriter(this.logFileHMD, true);
				tw.WriteLine(message);
				tw.Close(); 
			}
		}
	}

	//opens the map log
	public void startPhoneLog()
	{
		
		if(this.activeLogging)
		{
			if(File.Exists(this.logFilePhone))
			{
				twMap = new StreamWriter(this.logFilePhone, true);
				
			}
		}
	}

	//writing to the map log with timestamp
	public void writePhoneToLog(string message)
	{
		if(twMap == null)
			startPhoneLog();
		if(this.activeLogging)
		{
			if(File.Exists(this.logFilePhone))
			{	
				twMap.WriteLine(Time.realtimeSinceStartup.ToString() + ";" +message);
				//twMap.Flush();
			}
		}
	}

	//closing of map log
	public void closePhoneLog()
	{
		if(this.activeLogging)
		{
			if(File.Exists(this.logFilePhone))
			{
			
				twMap.Close(); 
			}
		}
	}




	//opens the HMD log
	public void startHMDLog()
	{
		

		if(this.activeLogging)
		{
			if(File.Exists(this.logFileHMD))
			{
				_twHMD = new StreamWriter(this.logFileHMD, true);
				Debug.Log("created");
				
			}
		}
	}

	//writing to the map log with timestamp
	public void writeHMDToLog(string message)
	{
		if(_twHMD == null)
			startHMDLog();
		if(this.activeLogging)
		{
			if(File.Exists(this.logFileHMD))
			{	
				_twHMD.WriteLine(Time.realtimeSinceStartup.ToString() + ";" +message);
				//twMap.Flush();
			}
		}
	}

	//closing of map log
	public void closeHMDLog()
	{
		if(this.activeLogging)
		{
			if(File.Exists(this.logFileHMD))
			{
				_twHMD.Close(); 
			}
		}
	}


	/// <summary>
	/// Writes the message including timestamp to the log file on disk.
	/// </summary>
	/// <param name="message">string representing the message to be written.</param>
	public void writeMessageWithTimestampToLog(string message)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + message);
	}


	/// <summary>
	/// Writes an Action-Object-Target message including timestamp to the log file on disk.
	/// </summary>
	/// <param name="act">string representing the ACTION message.</param>
	/// <param name="obj">string representing the OBJECT message.</param>
	/// <param name="tar">string representing the TARGET message.</param>
	public void writeAOTMessageWithTimestampToLog(string act, string obj, string tar)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + act + ";" + obj + ";" + tar);
	}
		

	/// <summary>
	/// Writes the Action-Object-Target-Origin-State message with timestamp to log.
	/// </summary>
	/// <param name="act">string representing the ACTION message.</param>
	/// <param name="obj">string representing the OBJECT message.</param>
	/// <param name="tar">string representing the TARGET message.</param>
	/// <param name="origin">string representing the ORIGIN message.</param>
	/// <param name="state">string representing the STATE message.</param>
	/// <param name="state">string representing the MODE message.</param>
	public void writeAOTOSMMessageWithTimestampToLog(string act, string obj, string tar, string origin, string state, string mode)
	{
		writeMessageToLog(Time.realtimeSinceStartup.ToString() + ";" + act + ";" + obj + ";" + tar + ";" + origin + ";" + state + ";" + mode);
	}

	#endregion
}