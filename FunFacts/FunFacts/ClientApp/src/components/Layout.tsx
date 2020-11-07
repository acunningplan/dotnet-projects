import React from "react";
import { Container } from "reactstrap";
import { NavMenu } from "./NavMenu";

export const Layout : React.FunctionComponent<{}> = props => {
  // static displayName = Layout.name;

  return (
    <div>
      <NavMenu />
      <Container>{props.children}</Container>
    </div>
  );
};
