describe("Login by Google", () => {
  const apiUrl = "https://localhost:5001";
  it("Visits TravelBug home", () => {
    // Login by Google as James
    localStorage.setItem(
      "travelBug:Token",
      "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJnb29nbGVfMTA0NzczODQwMjY3MzQzMjE2MTQ0IiwibmJmIjoxNjA1MDAzNzA0LCJleHAiOjE2MDU2MDg1MDQsImlhdCI6MTYwNTAwMzcwNH0.CkgV2pIvEehvDq7YshKPZzL5huillPKE-b78j_sDw-yFaH-sJxzMVwMEpfJpvuK1fo3ov1r-J4_vV-fqzplU3g"
    );
    localStorage.setItem("travelBug:Username", "google_104773840267343216144");

    cy.visit(`${apiUrl}/`);

    cy.contains("Blogs").click();
    cy.get("h3")
      .should("contain.text", "Blogs")
      .should("contain.text", "Featured users");
  });
});
