import React, { useState } from "react";
import { environment } from "../../environment";
import axios from "axios";
import { Button, Form, FormGroup, Input, Label, ListGroup } from "reactstrap";
import "./SignIn.css";
import FunFact from "../FunFact/FunFact";

class LoginResponse {
  bio = "";
  username = "";
  displayName = "Guest";
  lastLogin = "";
  funFacts: FunFact[] = [];
  token = "";
  refreshToken = "";
}

export const SignIn = () => {
  let [isFormHidden, setIsFormHidden] = useState(true);
  let [isSignUp, setIsSignUp] = useState(false);
  let loginInput = { email: "", password: "" };

  const handleEmail = (e: React.ChangeEvent<HTMLInputElement>) => {
    loginInput.email = e.target.value;
  };

  const handlePassword = (e: React.ChangeEvent<HTMLInputElement>) => {
    loginInput.password = e.target.value;
  };

  async function emailLogin() {
    console.log(loginInput);
    const res = await axios.post<{ data: LoginResponse }>(
      `${environment.apiUrl}/user/login`,
      { email: "sarah@test.com", password: "Pa$$w0rd" }
    );
    console.log(res.data);
    return res.data;
  }

  return (
    <>
      <ListGroup className="login-list" hidden={!isFormHidden}>
        <Button className="google-login">Google Login</Button>
        <Button className="email-login" onClick={() => setIsFormHidden(false)}>
          Email Login
        </Button>
      </ListGroup>

      <Form hidden={isFormHidden}>
        {isSignUp && (
          <p className="sign-up-toggle" onClick={() => setIsSignUp(false)}>
            Sign in
          </p>
        )}
        {!isSignUp && (
          <p className="sign-up-toggle" onClick={() => setIsSignUp(true)}>
            Sign up
          </p>
        )}
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            type="email"
            name="email"
            id="email"
            onChange={handleEmail}
          ></Input>
        </FormGroup>
        <FormGroup hidden={!isSignUp}>
          <Label for="displayName">Display name</Label>
          <Input
            type="text"
            name="displayName"
            id="displayName"
            onChange={handlePassword}
          ></Input>
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            type="password"
            name="password"
            id="password"
            onChange={handlePassword}
          ></Input>
        </FormGroup>
        <FormGroup hidden={!isSignUp}>
          <Label for="confirm-password">Confirm password</Label>
          <Input
            type="password"
            name="confirm-password"
            id="confirm-password"
            onChange={handlePassword}
          ></Input>
        </FormGroup>
        <Button color="primary" onClick={emailLogin}>
          Submit
        </Button>{" "}
        <Button onClick={() => setIsFormHidden(true)}>Back</Button>
      </Form>
    </>
  );
};
