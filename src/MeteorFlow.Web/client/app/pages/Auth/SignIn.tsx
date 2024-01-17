import React, { useState, ChangeEvent, FormEvent } from "react";
import { NavLink } from 'react-router-dom';

interface SignInFormState {
  email: string;
  password: string;
}

const SignInForm: React.FC = () => {
  const [state, setState] = useState<SignInFormState>({
    email: "",
    password: ""
  });

  const handleChange = (evt: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = evt.target;
    setState({
      ...state,
      [name]: value
    });
  };

  const handleOnSubmit = (evt: FormEvent) => {
    evt.preventDefault();

    const { email, password } = state;
    alert(`You are logged in with email: ${email} and password: ${password}`);

    const initialState: SignInFormState = {
      email: "",
      password: ""
    };

    setState(initialState);
    window.location.href = "../home";   
  };

  return (
    <div className="form-container sign-in-container">
      <form onSubmit={handleOnSubmit}>
        <h1>Sign in</h1>
        <div className="social-container">
          <a href="#" className="social">
            <i className="fab fa-facebook-f" />
          </a>
          <a href="#" className="social">
            <i className="fab fa-google-plus-g" />
          </a>
          <a href="#" className="social">
            <i className="fab fa-linkedin-in" />
          </a>
        </div>
        <span>or use your account</span>
        <input
          type="email"
          name="email"
          value={state.email}
          onChange={handleChange}
          placeholder="Email"
        />
        <input
          type="password"
          name="password"
          value={state.password}
          onChange={handleChange}
          placeholder="Password"
        />
        <a href="#">Forgot your password?</a>
        <button>Sign In</button>
      </form>
    </div>
  );
};

export default SignInForm;
