using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class PlayAudio : MonoBehaviour
{
    public float distanceThreshold = 1.0f; // La distance à laquelle l'audio sera joué
    public KeyCode keyboardKey = KeyCode.E; // La touche du clavier pour jouer l'audio
    public KeyCode controllerKey = KeyCode.JoystickButton0; // La touche de la manette pour jouer l'audio
    public Canvas canvasTemplate; // Le canvas contenant le texte
    public GameObject playerArmature; // L'armature du joueur
    public TextMeshProUGUI TextToDisplay; // Le texte à afficher
    public string TextToDisplayString; // Le texte à afficher
    public TextMeshProUGUI KeyboardKeyText; // Le texte à afficher
    public Image ControllerKeyImage; // Le texte à afficher
    private Canvas canvas; // Le canvas contenant le texte

    void Update()
    {
        // Calculer la distance entre le joueur et l'objet
        float distance = Vector3.Distance(transform.position, playerArmature.transform.position);

        // Vérifier si le joueur est assez proche
        if (distance <= distanceThreshold)
        {
            // Afficher le texte
            canvas.enabled = true;

            // Vérifier si l'utilisateur a appuyé sur la touche spécifiée
            if (Input.GetKeyDown(keyboardKey) || Input.GetKeyDown(controllerKey))
            {
            }
        } else
        {
            // Cacher le texte
            canvas.enabled = false;
        }
    }

    void Start()
    {
        canvasTemplate.enabled = false;

        // Changer le texte à afficher
        TextToDisplay.text = TextToDisplayString;

        // Changer le texte sur KeyboardKeyText et ControllerKeyImage
        KeyboardKeyText.text = keyboardKey.ToString();

        // Changer le sprite sur ControllerKeyImage
        // ControllerKeyImage.sprite = Resources.Load<Sprite>(controllerKey.ToString());

        // Dupliquer le canvas template et l'afficher
        canvas = Instantiate(canvasTemplate, transform.position, Quaternion.identity);

        // Afficher le texte
        canvas.enabled = false;
    }
}