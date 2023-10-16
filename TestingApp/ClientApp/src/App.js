import React, { Component, lazy, Suspense } from "react";
import { Route, Switch, BrowserRouter as Router } from "react-router-dom";
import userRoutes from "./routes/userRoutes";

const LoginPage = lazy(() => import("./views/loginPage/LoginPage"));
const UserLayout = lazy(() => import("./layouts/userLayout/userLayout"));
class App extends Component {
  render() {
    return (
      <Router>
        <Suspense fallback={<div>Loading</div>}>
          <Switch>
            <Route
              exact
              path="/"
              name="LoginPage"
              render={(props) => <LoginPage {...props} />}
            />
            <Route
              path="/user"
              name="UserLayout"
              render={(props) => (
                <UserLayout {...props}>
                  <Switch>
                    {userRoutes.map((route, idx) => (
                      <Route
                        key={idx}
                        path={route.path}
                        exact={route.exact}
                        name={route.name}
                        render={(props) => <route.component {...props} />}
                      />
                    ))}
                  </Switch>
                </UserLayout>
              )}
            />
          </Switch>
        </Suspense>
      </Router>
    );
  }
}

export default App;
