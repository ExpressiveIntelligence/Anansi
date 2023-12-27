using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;

namespace Calypso.Scheduling
{
    public class ScheduleManager : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Path to this character's schedule in the Streaming Assets folder.
        /// </summary>
        [SerializeField]
        private List<TextAsset> scheduleXmlFiles;

        /// <summary>
        /// All schedule entries associated with a character
        /// </summary>
        private ScheduleCollection _schedules;

        #endregion

        #region Unity Lifecycle Methods

        private void Awake()
        {
            _schedules = new ScheduleCollection();
        }

        private void Start()
        {
            foreach (var textFile in scheduleXmlFiles)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(textFile.text);

                var scheduleDefinitionNodes = doc.GetElementsByTagName("ScheduleDefinition");

                for (int i = 0; i < scheduleDefinitionNodes.Count; i++)
                {
                    XmlNode node = scheduleDefinitionNodes[i];
                    Schedule schedule = Schedule.ParseXml(node);
                    _schedules.AddSchedule(schedule);
                }
            }

            Debug.Log($"Loaded {_schedules.Count} schedules");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get an entry from the schedule given the time of day.
        /// </summary>
        /// <param name="timeOfDay"></param>
        /// <returns></returns>
        public ScheduleEntry GetEntry(TimeOfDay timeOfDay)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
