using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace WeatherService
{
    class TemporaryWeatherFile
    {
        DateTime timeTemporaryFile;
        string temporaryFilePath;
        string temporaryDirectoryPath;
        XmlDocument xmlDoc;
        bool inMemory;

        #region public Properties
        public XmlDocument XmlDoc
        {
            get { return xmlDoc; }
            set { xmlDoc = value; }
        }

        public DateTime TimeTemporaryFile
        {
            get { return timeTemporaryFile; }
            set { timeTemporaryFile = value; }
        }

        public bool InMemory
        {
            get { return inMemory; }
        }
        #endregion

        #region public Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TemporaryWeatherFile(string filePath, string directoryPath)
        {
            this.temporaryFilePath = filePath;
            this.temporaryDirectoryPath = directoryPath;
            CreateTemporaryWheaterXmlFile();
            this.timeTemporaryFile = new FileInfo(this.temporaryFilePath).CreationTime;
            xmlDoc = new XmlDocument();
        }
        #endregion Counstructors

        #region private Methods
        /// <summary>
        /// Create temporary file
        /// </summary>
        private void CreateTemporaryWheaterXmlFile()
        {
            if (!File.Exists(this.temporaryFilePath))
            {
                if (!Directory.Exists(this.temporaryDirectoryPath))
                {
                    Directory.CreateDirectory(this.temporaryDirectoryPath);
                }
                System.IO.FileStream file = File.Create(this.temporaryFilePath);
                file.Close();
                this.inMemory = false;
            }
        }
        #endregion Private Methods
        
        #region Public Methods
        /// <summary>
        /// gets Length od XML file
        /// </summary>
        /// <returns>long length</returns>
        public long Length()
        {
            return new FileInfo(temporaryFilePath).Length;
        }

        /// <summary>
        /// Load file from disk
        /// </summary>
        public void LoadFromDisk()
        {
            this.xmlDoc.Load(this.temporaryFilePath);
            this.inMemory = true;
        }

        /// <summary>
        /// Save file to disk
        /// </summary>
        public void SaveToDisk()
        {
            this.xmlDoc.Save(this.temporaryFilePath);
            this.timeTemporaryFile = new FileInfo(this.temporaryFilePath).LastWriteTime;

        }

        /// <summary>
        /// Load XML to temporary file
        /// </summary>
        /// <param name="xml"></param>
        public void LoadXml(string xml)
        {
            this.xmlDoc.LoadXml(xml);
            SaveToDisk();
        }
        #endregion Public Methods
    }

}
