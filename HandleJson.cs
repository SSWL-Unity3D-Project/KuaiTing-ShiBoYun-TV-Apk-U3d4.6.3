﻿using UnityEngine;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System;

public class HandleJson {

	private static  HandleJson Instance;
	public static HandleJson GetInstance()
	{
		if (Instance==null) {
			Instance = new HandleJson();
		}
		return Instance;
	}

	public void ExeCommand()
	{
		Process p = new Process();
		p.StartInfo.FileName = "checkIp.exe";
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.RedirectStandardInput = true;
		p.StartInfo.RedirectStandardOutput = true;
		p.StartInfo.RedirectStandardError = true;
		p.StartInfo.CreateNoWindow = true;//true表示不显示黑框，false表示显示dos界面
		//string strOutput = null;
		p.Start();
		//要执行的dos命令  p.StandardInput.WriteLine("");
		//p.StandardInput.WriteLine("exit");
		
		//p.Close();
	}

	//write to file
	//fileName: the file name with path
	//attribute: the attribute name
	//valueStr: write the value to the file
	public void WriteToFileXml(string fileName, string attribute, string valueStr)
	{
        return;
		string filepath = Application.dataPath + "/" + fileName;
		#if UNITY_ANDROID
		filepath = Application.persistentDataPath + "//" + fileName;
		#endif
		
		//create file
		if(!File.Exists (filepath))
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlElement root = xmlDoc.CreateElement("transforms");
			XmlElement elmNew = xmlDoc.CreateElement("attribute");
			
			root.AppendChild(elmNew);
			xmlDoc.AppendChild(root);
			xmlDoc.Save(filepath);
			File.SetAttributes(filepath, FileAttributes.Normal);
		}
		
		//update value
		if(File.Exists (filepath))
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filepath);
			XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
			
			foreach(XmlElement xe in nodeList)
			{
				xe.SetAttribute(attribute, valueStr);
			}
			File.SetAttributes(filepath, FileAttributes.Normal);
			xmlDoc.Save(filepath);
		}
	}

	
	public void WriteToFilePathXml(string filepath, string attribute, string valueStr)
    {
        return;
        //string filepath = Application.dataPath + "/" + fileName;
#if UNITY_ANDROID
        //		filepath = Application.persistentDataPath + "//" + fileName;
#endif

        //create file
        if (!File.Exists (filepath))
		{
			XmlDocument xmlDoc = new XmlDocument();
			XmlElement root = xmlDoc.CreateElement("transforms");
			XmlElement elmNew = xmlDoc.CreateElement("attribute");
			
			root.AppendChild(elmNew);
			xmlDoc.AppendChild(root);
			xmlDoc.Save(filepath);
			File.SetAttributes(filepath, FileAttributes.Normal);
		}
		
		//update value
		if(File.Exists (filepath))
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filepath);
			XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
			
			foreach(XmlElement xe in nodeList)
			{
				xe.SetAttribute(attribute, valueStr);
			}
			File.SetAttributes(filepath, FileAttributes.Normal);
			xmlDoc.Save(filepath);
		}
	}
	
	//read information according to the attribute
	//return the string type value
	//int aaa = int.Parse(valueStr);
	//int.TryParse(valueStr, out aaa);
	public string ReadFromFileXml(string fileName, string attribute)
    {
        return "";
        string filepath = Application.dataPath + "/" + fileName;
		#if UNITY_ANDROID
		filepath = Application.persistentDataPath + "//" + fileName;
		#endif
		string valueStr = null;
		
		if(File.Exists (filepath))
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(filepath);
				XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
				foreach(XmlElement xe in nodeList)
				{
					valueStr = xe.GetAttribute(attribute);
				}
				File.SetAttributes(filepath, FileAttributes.Normal);
				xmlDoc.Save(filepath);
			}			
			catch (Exception exception)
			{
				File.SetAttributes(filepath, FileAttributes.Normal);
				File.Delete(filepath);
				UnityEngine.Debug.LogError("error: xml was wrong! " + exception);
			}
		}
		return valueStr;
	}

	public string ReadFromFilePathXml(string filepath, string attribute)
    {
        return "";
        //string filepath = Application.dataPath + "/" + fileName;
#if UNITY_ANDROID
        //filepath = Application.persistentDataPath + "//" + fileName;
#endif
        string valueStr = null;
		
		if(File.Exists (filepath))
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filepath);
			XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
			foreach(XmlElement xe in nodeList)
			{
				valueStr = xe.GetAttribute(attribute);
			}
			File.SetAttributes(filepath, FileAttributes.Normal);
			xmlDoc.Save(filepath);
		}
		
		return valueStr;
	}
}
