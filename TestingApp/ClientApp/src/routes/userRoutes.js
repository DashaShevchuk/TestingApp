import {lazy} from 'react';

const AvailableTests = lazy(() => import('../views/userViews/availableTests/AvailableTests'));
const CompletedTests = lazy(()=>import('../views/userViews/completedTests/CompletedTests'));
const TestPreview= lazy(()=>import('../views/userViews/testPreview/TestPreview'));
const Test = lazy(()=>import('../views/userViews/test/Test'));

const routes = [
  { path: "/user/available", exact: true, name: "AvailableTests", component: AvailableTests },
  { path: "/user/completed", exact: true, name: "CompletedTests", component: CompletedTests },
  { path: "/user/available/:testId", exact: true, name: "TestPreview", component: TestPreview },
  { path: "/user/:testId", exact: true, name: "Test", component: Test }
];

export default routes;