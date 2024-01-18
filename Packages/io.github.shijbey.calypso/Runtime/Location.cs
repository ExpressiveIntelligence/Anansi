using System.Collections.Generic;
using TDRS;
using UnityEngine;

namespace Calypso
{
    /// <summary>
    /// A place where characters can be. Locations are displayed as the background images
    /// in the game.
    /// </summary>
    public class Location : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// The name of the location as displayed in the UI.
        /// </summary>
        [SerializeField]
        protected string m_displayName;

        /// <summary>
        /// An ID that uniquely identifies this location among other locations in the game.
        /// </summary>
        [SerializeField]
        protected string m_uniqueID;

        /// <summary>
        /// A reference to the game's social engine
        /// </summary>
        [SerializeField]
        protected SocialEngine m_socialEngine;

        /// <summary>
        /// Collection of all characters currently at this location
        /// </summary>
        protected List<Actor> m_actors = new List<Actor>();

        /// <summary>
        /// A reference to the sprite controller attached to this GameObject
        /// </summary>
        protected SpriteController m_spriteController;

        #endregion

        #region Properties

        /// <summary>
        /// The name of the location as displayed in the UI.
        /// </summary>
        public string DisplayName => m_displayName;

        /// <summary>
        /// An ID that uniquely identifies this location among other locations in the game.
        /// </summary>
        public string UniqueID => m_uniqueID;

        /// <summary>
        /// Collection of all characters currently at this location
        /// </summary>
        public IEnumerable<Actor> Characters => m_actors;

        #endregion

        #region Unity Messages

        private void Awake()
        {
            m_spriteController = GetComponent<SpriteController>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the currently displayed sprite using the given tags
        /// </summary>
        /// <param name="tags"></param>
        public void SetSprite(params string[] tags)
        {
            if (m_spriteController == null) return;

            m_spriteController.SetSpriteFromTags(tags);
        }

        /// <summary>
        /// Remove a character from the location
        /// </summary>
        /// <param name="actor"></param>
        public void AddCharacter(Actor actor)
        {
            m_actors.Add(actor);
        }

        /// <summary>
        /// Add a character to the location
        /// </summary>
        /// <param name="actor"></param>
        public void RemoveCharacter(Actor actor)
        {
            m_actors.Remove(actor);
        }

        #endregion
    }
}
