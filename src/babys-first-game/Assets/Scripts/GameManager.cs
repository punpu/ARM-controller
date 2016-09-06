using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // Limb points for pose scoring
    public Transform RightPumpArmPoint;
    public Transform RightArmPoint;

    public Transform LeftPumpArmPoint;
    public Transform LeftArmPoint;

    public Transform RightPumpLegPoint;
    public Transform RightLegPoint;

    public Transform LeftPumpLegPoint;
    public Transform LeftLegPoint;


    // Limb target points for a specific pose
    private Transform RightPumpArmTarget;
    private Transform RightArmTarget;

    private Transform LeftPumpArmTarget;
    private Transform LeftArmTarget;

    private Transform RightPumpLegTarget;
    private Transform RightLegTarget;

    private Transform LeftPumpLegTarget;
    private Transform LeftLegTarget;

    // Percentages for pose scoring
    private float rightPumpArmPercent;
    private float rightArmPercent;

    private float leftPumpArmPercent;
    private float leftArmPercent;

    private float rightPumpLegPercent;
    private float rightLegPercent;

    private float leftPumpLegPercent;
    private float leftLegPercent;

    private float currentPosePercentage;

    // All poses here
    public Transform[] Poses;

    public int posesLeftToGo;
    private int posesDone = 0;
    private float totalScore = 0f;
    private float totalPercentage = 0f;
    //private float finishedPoseScore;

    private bool poseFinished;

    // Currently active pose
    private Transform currentPose;

    // Timer for pose changing. timerMax changes according to the difficulty level
    private float timer;
    public float timerMax;

    public static bool HappyEnding;
    public static int FinalScore;

    public GUIStyle timerGUIStyle;
    public GUIStyle finishedPoseMessageStyle;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1f;
        posesLeftToGo = mainmenuscript.poses;
        if((int)mainmenuscript.difficulty_level == 0)
        {
            timerMax = 15;
        }
        else if ((int) mainmenuscript.difficulty_level == 1)
        {
            timerMax = 10;
        }
        else if ((int) mainmenuscript.difficulty_level == 2)
        {
            timerMax = 6;
        }

        int randomIndex = Random.Range(0, Poses.Length);
        changeTargetPose(Poses[randomIndex]);
        gameObject.SendMessage("DisplayPose", randomIndex);

        timer = timerMax;
    }


	// Update is called once per frame
	void Update () {

        calcTotalPercentage();
        updateTimerAndPose();

        if (Input.GetKeyDown("escape"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("mainmenu");
        }

    }

    Vector2 timerBarPos = new Vector2( Screen.width / 2, Screen.height - 50f);
    Vector2 timerBarSize = new Vector2(Screen.width, 25);
    public Texture2D timerBarFull;

    void OnGUI(){

        // Timer is shown as a progress bar
        GUI.DrawTexture(new Rect(timerBarPos.x * ( 1 - Mathf.Clamp01(timer / timerMax) ), timerBarPos.y, timerBarSize.x * Mathf.Clamp01(timer / timerMax), timerBarSize.y), timerBarFull);

        //GUI.Box(new Rect(50, 50, 300, 25), "Current percentage: " + currentPosePercentage.ToString("0") + " %");
        //GUI.Box(new Rect(50, 100, 300, 25), "Seconds until next pose: " + timer.ToString("0.0"), timerGUIStyle);
        GUI.Box(new Rect(50, 50, 200, 25), "Score: " + totalPercentage.ToString("0"), timerGUIStyle);
        GUI.Box(new Rect(Screen.width - 200, 200, 200, 25), "Poses left to perform: " + posesLeftToGo.ToString(), finishedPoseMessageStyle);

        if (poseFinished)
        {
            if (currentPosePercentage > 99f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "GODLIKE!", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage > 90f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "PERFECT POSE!", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage > 75f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "Magnificent!", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage > 60f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "Good, good", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage > 40f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "Your pose is... average", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage > 25f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "Miserable...", finishedPoseMessageStyle);
            }
            else if (currentPosePercentage >= 0f)
            {
                GUI.Box(new Rect(Screen.width / 2 - 100, 50, 200, 25), "Are you even trying?", finishedPoseMessageStyle);
            }

            GUI.Box(new Rect(Screen.width / 2 - 100, 80, 200, 25), currentPosePercentage.ToString("0") + " %", finishedPoseMessageStyle);
        }
    }


    private void calcTotalPercentage()
    {
        float rightPumpArmDistance = Vector2.Distance(RightPumpArmPoint.transform.position, RightPumpArmTarget.transform.position);
        float rightArmDistance = Vector2.Distance(RightArmPoint.transform.position, RightArmTarget.transform.position);

        rightPumpArmPercent = calcLimbPercentage(rightPumpArmDistance);
        rightArmPercent = calcLimbPercentage(rightArmDistance);

        float leftPumpArmDistance = Vector2.Distance(LeftPumpArmPoint.transform.position, LeftPumpArmTarget.transform.position);
        float leftArmDistance = Vector2.Distance(LeftArmPoint.transform.position, LeftArmTarget.transform.position);

        leftPumpArmPercent = calcLimbPercentage(leftPumpArmDistance);
        leftArmPercent = calcLimbPercentage(leftArmDistance);

        float rightPumpLegDistance = Vector2.Distance(RightPumpLegPoint.transform.position, RightPumpLegTarget.transform.position);
        float rightLegDistance = Vector2.Distance(RightLegPoint.transform.position, RightLegTarget.transform.position);

        rightPumpLegPercent = calcLimbPercentage(rightPumpLegDistance);
        rightLegPercent = calcLimbPercentage(rightLegDistance);

        float leftPumpLegDistance = Vector2.Distance(LeftPumpLegPoint.transform.position, LeftPumpLegTarget.transform.position);
        float leftLegDistance = Vector2.Distance(LeftLegPoint.transform.position, LeftLegTarget.transform.position);

        leftPumpLegPercent = calcLimbPercentage(leftPumpLegDistance);
        leftLegPercent = calcLimbPercentage(leftLegDistance);

        currentPosePercentage = (rightPumpArmPercent + rightArmPercent + leftPumpArmPercent + leftArmPercent +
                              rightPumpLegPercent + rightLegPercent + leftPumpLegPercent + leftLegPercent) / 8;
    }

    private float calcLimbPercentage(float limbDistance)
    {
        float limbPercentage;

        if (limbDistance < 0.5f)
        {
            limbPercentage = 100f;
        }
        else if (limbDistance > 2f)
        {
            limbPercentage = 0f;
        }
        else
        {
            limbPercentage = (1f - (limbDistance - 0.5f) / 1.5f) * 100f;
        }

        return limbPercentage;
    }

    private void changeTargetPose(Transform pose) {

        //Transform nextPose = (Transform)Instantiate(pose, new Vector3(0, 0, 0), Quaternion.identity);
        Transform nextPose = (Transform)Instantiate(pose, pose.transform.position, pose.transform.rotation);

        RightArmTarget = nextPose.GetChild(0);
        RightPumpArmTarget = nextPose.GetChild(1);

        LeftArmTarget = nextPose.GetChild(2);
        LeftPumpArmTarget = nextPose.GetChild(3);

        RightLegTarget = nextPose.GetChild(4);
        RightPumpLegTarget = nextPose.GetChild(5);

        LeftLegTarget = nextPose.GetChild(6);
        LeftPumpLegTarget = nextPose.GetChild(7);

        if (currentPose)
        {
            Destroy(currentPose.gameObject);
        }

        currentPose = nextPose;
    }


    private void updateTimerAndPose()
    {
        timer -= Time.deltaTime;
        if(timer < 0f)
        {
            timer = timerMax;

            // Finished pose score will be shown briefly after a pose is finished
            //finishedPoseScore = currentPosePercentage;
            StartCoroutine(showFinishedPoseAndSetUpNextPose());

            totalScore += currentPosePercentage;

            --posesLeftToGo;
            ++posesDone;

            if (posesDone > 0)
            {
                totalPercentage = totalScore / posesDone;
            }
            else
            {
                totalPercentage = totalScore;
            }

            

            if (posesLeftToGo == 0 )
            {
                if(totalPercentage < 50f)
                {
                    HappyEnding = false;
                }
                else
                {
                    HappyEnding = true;
                }
                FinalScore = (int) Mathf.Round(totalPercentage);
                UnityEngine.SceneManagement.SceneManager.LoadScene("endingscene");
            }
        }
    }

    private IEnumerator showFinishedPoseAndSetUpNextPose()
    {
        poseFinished = true;
        Time.timeScale = 0f;
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(4));
        poseFinished = false;
        Time.timeScale = 1f;

        int randomIndex = Random.Range(0, Poses.Length);
        changeTargetPose(Poses[randomIndex]);

        gameObject.SendMessage("DisplayPose", randomIndex);
    }
}

public static class CoroutineUtil
{
    public static IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }
}