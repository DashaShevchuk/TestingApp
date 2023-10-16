import React, { Suspense, Component } from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { logout } from "../../views/loginPage/reducer";
import routes from "../../routes/userRoutes";
import { connect } from "react-redux";
import get from "lodash.get";
import { Layout } from "antd";

const UserNavbar = React.lazy(() => import("./navbar"));
const UserSidebar = React.lazy(() => import("./sidebar"));

const { Header, Footer, Sider, Content } = Layout;

class UserLayout extends Component {
  loading = () => (
    <div className="animated fadeIn pt-1 text-center">Loading...</div>
  );

  signOut(e) {
    e.preventDefault();
    this.props.logout();
    this.props.history.push("/");
  }

  render() {
    const { login } = this.props;
    //console.log(login);
    let isAccess = true;
    if(login.isAuthenticated===undefined){
        return (
            <Redirect to="/" />  
          );
    }
    if(login.isAuthenticated)
    {
      const { roles } = login.user;
      for (let i = 0; i < roles.length; i++) {
        if (roles[i] === 'User')
          isAccess = true;
      }
    }
    const content = (
      <div className="app">
        <Layout>
          <Suspense fallback={<div>Loading...</div>}>
            <UserSidebar />
          </Suspense>
          <Layout>
            <UserNavbar />
            <Content>
              <Suspense fallback={<div>Loading...</div>}>
                <Switch>
                  {routes.map((route, idx) =>
                    route.component ? (
                      <Route
                        key={idx}
                        path={route.path}
                        exact={route.exact}
                        name={route.name}
                        render={(routeProps) => (
                          <route.component {...routeProps} />
                        )}
                      />
                    ) : null
                  )}
                  <Redirect from="/" to="/user/available" />
                </Switch>
              </Suspense>
            </Content>
          </Layout>
        </Layout>
      </div>
    );
    return isAccess ? content : <Redirect to="/" />;
  }
}
const mapStateToProps = (state) => {
  return {
    login: get(state, "login"),
  };
};

export default connect(mapStateToProps, { logout })(UserLayout);
