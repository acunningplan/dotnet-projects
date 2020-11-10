describe("Login by Google", () => {
  const apiUrl = "https://localhost:5001";
  it("Visits TravelBug home", () => {
    cy.visit(`${apiUrl}/`);

    cy.contains("Sign up / login").click();
    cy.url().should("include", "/account");

    cy.get("u").contains("Sign up").click();
    cy.get("form").should("contain.text", "Confirm password");

    const fakeEmail = "fake-email@gmail.com";
    cy.get("[name='email']").type(fakeEmail).should("have.value", fakeEmail);

    cy.contains("Login by Google").click();
    cy.type("jlfly12@gmail.com").submit();
  });
});
