using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UTMSequenceManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text instructionText;
    [SerializeField] private Button nextButton;
   
    private int currentStep = 0;
    private bool canProceed = true;

    void Start()
    {
        // Initialize with first step
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(HandleNextButtonClick);
            UpdateSequence();
        }
    }

    void HandleNextButtonClick()
    {
        if (canProceed)
        {
            currentStep++;
            UpdateSequence();
        }
    }

    void UpdateSequence()
    {
        // Disable button until current step is complete
        nextButton.interactable = canProceed;

        switch (currentStep)
        {
            case 0:
                // Initial state
                instructionText.text = "Welcome to UTM Simulation. Click Next to begin.";
                canProceed = true;
                break;

            case 1:
                // First step
                instructionText.text = "Step 1: Initializing Firewall Configuration";
                StartCoroutine(SimulateStep(2.0f)); // Example delay
                break;

            case 2:
                // Second step
                instructionText.text = "Step 2: Setting up Intrusion Detection System";
                StartCoroutine(SimulateStep(3.0f));
                break;

            case 3:
                // Third step
                instructionText.text = "Step 3: Configuring VPN Settings";
                StartCoroutine(SimulateStep(2.5f));
                break;

            // Add more cases as needed

            default:
                // Reset or end simulation
                instructionText.text = "Simulation Complete. Click Next to restart.";
                currentStep = -1; // Will become 0 on next click
                canProceed = true;
                break;
        }
    }

    IEnumerator SimulateStep(float duration)
    {
        canProceed = false;
        nextButton.interactable = false;
       
        // Wait for the step duration
        yield return new WaitForSeconds(duration);
       
        canProceed = true;
        nextButton.interactable = true;
    }
}