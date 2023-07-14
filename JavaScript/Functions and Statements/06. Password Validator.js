function passwordValidator(password) {
  function lengthValidator() {
    if (password.length < 6 || password.length > 10) {
      console.log("Password must be between 6 and 10 characters");
      return false;
    } else {
      return true;
    }
  }

  function consistValidator() {
    if (/^[A-Za-z0-9]*$/.test(password)) {
      return true;
    } else {
      console.log("Password must consist only of letters and digits");
      return false;
    }
  }

  function minAmountOfDigitsValidator() {
    if (/\d.*\d/.test(password)) {
      return true;
    } else {
      console.log("Password must have at least 2 digits");
      return false;
    }
  }

  let firstTest = lengthValidator();
  let secondTest = consistValidator();
  let thirdthTest = minAmountOfDigitsValidator()

  if (firstTest && secondTest && thirdthTest) {
    console.log("Password is valid");
  }
}

passwordValidator("Pa$s$s");
