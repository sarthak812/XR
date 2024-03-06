using UnityEngine;

public class CubeController : MonoBehaviour {
  /***** Public Variables *****/
  [Header("Cube Colors")] 
  public Color defaultColor   = Color.white;
  public Color highlightColor = Color.yellow;
  public Color clickedColor   = Color.black;

  [Header("Cube Configuration")] 
  public bool isStartingCube = false;
  
  public bool isClicked { get; private set; }
  
  /***** Private Variables *****/
  private bool _isHighlighted = false;

  /***** Unity Methods *****/
  private void Start() { 
    // If this is the starting cube, set it to the highlight color
    if (isStartingCube) {
      gameObject.GetComponent<Renderer>().material.color = highlightColor;
    }
    // If this is not the starting cube, set it to the default color
    else {
      gameObject.GetComponent<Renderer>().material.color = defaultColor;
    }
  }

  /***** Public Methods *****/
  public void OnClick() {
    // Ignore if the Cube is already clicked
    if (isClicked) return;
    
    // If the game has not started
    if (GameController.isGameStarted == false) {
      // And this cube is not the starting cube, then do nothing
      if (isStartingCube == false) return;
      // Otherwise, start the game and update it's state
      GameController.StartGame();
      isClicked = true;
      _isHighlighted = false;
      gameObject.GetComponent<Renderer>().material.color = clickedColor;
    }
    // If the game has started
    else {
      // Then update the state of the cube
      isClicked = true;
      _isHighlighted = false;
      // And it's color 
      gameObject.GetComponent<Renderer>().material.color = clickedColor;
    }
  }
  
  /** Highlights the Cube for a single frame */
  public void Highlight() {
    // Ignore if the Cube is already clicked or highlighted
    if (isClicked || _isHighlighted) return;

    // Otherwise, highlight the cube
    gameObject.GetComponent<Renderer>().material.color = highlightColor;
    _isHighlighted = true;
  }
  
  public void UnHighlight() {
    // Ignore if the Cube is not highlighted
    if(_isHighlighted == false) return;
    
    // Otherwise, unhighlight the cube
    gameObject.GetComponent<Renderer>().material.color = defaultColor;
    _isHighlighted = false;
  }
}