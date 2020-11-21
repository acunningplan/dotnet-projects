describe("My First Test", () => {
  it("Does not do much!", () => {
    expect(true).to.equal(true);
  });
});

describe("My First Test", () => {
  it("Visits the Kitchen Sink", () => {
    cy.visit("https://example.cypress.io");

    cy.contains("type").click();

    cy.url().should("include", "/commands/actions");

    const fakeEmail = "fake-email@gmail.com";
    cy.get(".action-email").type(fakeEmail).should("have.value", fakeEmail);
    cy.get("a")
  });
});
