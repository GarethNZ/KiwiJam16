using UnityEngine;
using System.Collections.Generic;

public class InputRandomizer : MonoBehaviour {

    public class DualAxisInput
    {
        public string horizontal;
        public string vertical;
        public DualAxisInput(string h, string v)
        {
            horizontal = h;
            vertical = v;
        }
    }

    // TODO: Support more states and dividing by total number of controllers (2-4p games)
    public enum DualInputSet
    {
        A, B, C, D, E, F
    }

    public static Dictionary<DualInputSet, DualAxisInput> inputMaps = new Dictionary<DualInputSet, DualAxisInput>();

    // Use this for initialization before other things Start
    void Awake() {
        foreach(DualInputSet set in System.Enum.GetValues(typeof(DualInputSet)))
        {
            int randomOption = Random.Range(0, dualAxisInputOptions.Count);
            Debug.Log("Set " + set + " mapped to " + dualAxisInputOptions[randomOption].horizontal + " and " + dualAxisInputOptions[randomOption].vertical);
            inputMaps.Add(set, dualAxisInputOptions[randomOption]);
            dualAxisInputOptions.RemoveAt(randomOption);
        }
    }


    // Known dual axis pair that will be randomly assigned to a DualInputSet
    private static List<DualAxisInput> dualAxisInputOptions = new List<DualAxisInput>() {
        new DualAxisInput("Horizontal", "Vertical"),
        new DualAxisInput("Horizontal_b", "Vertical_b"),
        new DualAxisInput("2Horizontal", "2Vertical"),
        new DualAxisInput("2Horizontal_b", "2Vertical_b"),
        new DualAxisInput("3Horizontal", "3Vertical"),
        new DualAxisInput("3Horizontal_b", "3Vertical_b")
    };
}
