using Services;
using SkillBridge.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    public InputField username;
    public InputField password;
    // Start is called before the first frame update
    void Start()
    {
        UserService.Instance.OnLogin = OnLogin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(this.username.text))
        {
            MessageBox.Show("请输入账号");
            return;
        }
        if (string.IsNullOrEmpty(this.password.text))
        {
            MessageBox.Show("请输入密码");
            return;
        }
        UserService.Instance.SendLogin(this.username.text, this.password.text);
    }
    void OnLogin(Result result, string message)
    {
        if (result == Result.Success)
        {
            //登录成功，进入角色选择
            MessageBox.Show("登录成功", "提示", MessageBoxType.Information).OnYes = this.CloseRegister;
        }
        else
            MessageBox.Show(message, "错误", MessageBoxType.Error);
    }

    void CloseRegister()
    {
        this.gameObject.SetActive(false);
    }
}
