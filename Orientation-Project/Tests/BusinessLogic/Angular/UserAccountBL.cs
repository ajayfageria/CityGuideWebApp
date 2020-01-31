using System;
using Tests.CommonUtils;
using Tests.PageObject;

namespace Tests.BusinessLogic.Angular
{
    class UserAccountBL
    {
        CommonMethods commonuitils = new CommonMethods();
        RegistrationForm registrationForm;
        LoginForm loginform;
        public bool fillupRegistrationform(string UserName, string Password, string Email, string FullName)
        {
            try
            {
                registrationForm = new RegistrationForm();
                commonuitils.typetext(registrationForm.UsernameInput(), UserName);
                commonuitils.typetext(registrationForm.FullNameInput(), FullName);
                commonuitils.typetext(registrationForm.EmailInput(), Email);
                commonuitils.typetext(registrationForm.PasswordInput(), Password);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw e;
            }
        }
        public bool clickOnBtn(string Btn) {
            if (Btn.Equals("Signup")){
                commonuitils.click(registrationForm.SignupBtn());
                return true;
            }
            else if (Btn.Equals("Login"))
            {
                commonuitils.click(loginform.LoginBtn());
                return true;
            }
            else
                return false;
        }

        public bool successinreg() {
            if (commonuitils.gettext(registrationForm.UsernameInput()).Equals(""))
            {
                return true;
            }
            else
                return false;
        }
    }
}
