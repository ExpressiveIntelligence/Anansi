using System;
using UnityEngine;
using UnityEngine.UI;

namespace Anansi
{
	/// <summary>
	/// This controller listens for input request actions from the StoryController, and responds
	/// with input provided by the user.
	/// </summary>
	class InputPanelController : MonoBehaviour
	{
		[SerializeField]
		private Button m_submitButton;

		[SerializeField]
		private TMPro.TMP_Text m_textArea;

		[SerializeField]
		private TMPro.TMP_InputField m_inputField;

		[SerializeField]
		private StoryController m_storyController;

		private InputDataType m_requestDataType;

		private string m_requestVariableName;

		[SerializeField]
		private TMPro.TMP_Text m_errorText;

		private void Start()
		{
			m_requestDataType = InputDataType.String;
			m_requestVariableName = "";
			m_submitButton.onClick.AddListener( SubmitInput );
			// m_storyController.OnGetInput += HandleGetInput;
			Hide();
		}

		public void HandleGetInput(InputRequest request)
		{
			m_textArea.text = request.Prompt;
			m_requestDataType = request.DataType;
			m_requestVariableName = request.VariableName;
			Show();
		}

		public void Show()
		{
			gameObject.SetActive( true );
		}

		public void Hide()
		{
			gameObject.SetActive( false );
		}

		/// <summary>
		/// Send the input to the StoryController.
		/// </summary>
		public void SubmitInput()
		{
			string inputText = m_inputField.text;

			switch ( m_requestDataType )
			{
				case InputDataType.String:
					m_storyController.SetInput( m_requestVariableName, inputText );
					m_errorText.text = "";
					m_inputField.text = "";
					m_errorText.gameObject.SetActive( false );
					Hide();
					break;
				case InputDataType.Int:
					if ( int.TryParse( inputText, out var intValue ) )
					{
						m_storyController.SetInput( m_requestVariableName, intValue );
						m_errorText.text = "";
						m_inputField.text = "";
						m_errorText.gameObject.SetActive( false );
						Hide();
					}
					else
					{
						m_errorText.text = "Please enter valid integer.";
						m_errorText.gameObject.SetActive( true );
					}
					break;
				case InputDataType.Float:
					if ( float.TryParse( inputText, out var floatValue ) )
					{
						m_storyController.SetInput( m_requestVariableName, floatValue );
						m_errorText.text = "";
						m_inputField.text = "";
						m_errorText.gameObject.SetActive( false );
						Hide();
					}
					else
					{
						m_errorText.text = "Please enter valid number.";
						m_errorText.gameObject.SetActive( true );
					}
					break;
			}
		}
	}
}
