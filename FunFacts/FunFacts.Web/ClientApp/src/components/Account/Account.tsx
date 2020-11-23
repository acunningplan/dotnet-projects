import React from "react";
import { environment } from "../../environment";
import { LoginResponse } from "../FunFacts/FunFacts";
import axios from "axios";
import { Card, CardGroup } from "reactstrap";

export const Account = () => {
  async function loginFunc() {
    const res = await axios.post<{ data: LoginResponse }>(
      `${environment.apiUrl}/api/user/login`,
      { email: "sarah@test.com", password: "Pa$$w0rd" }
    );
    console.log(res.data);
    return res.data;
  }

  return (
    <>
      <CardGroup>
        <Card>Google Login</Card>
        <Card onClick={loginFunc}>Email Login</Card>
      </CardGroup>
    </>
  );
};
