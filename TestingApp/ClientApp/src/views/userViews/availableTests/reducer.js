import AvailableTestsServices from "./AvailableTestsServices";
import update from "../../../helpers/update";

export const AVAILABLE_TESTS_STARTED = "AVAILABLE_TESTS_STARTED";
export const AVAILABLE_TESTS_SUCCESS = "AVAILABLE_TESTS_SUCCESS";
export const AVAILABLE_TESTS_FAILED = "AVAILABLE_TESTS_FAILED";

const initialState = {
  list: {
    data: null,
    loading: false,
    success: false,
    failed: false,
  }
};

export const getTests = () => {
  return (dispatch) => {
    dispatch(getListActions.started());
    AvailableTestsServices.getTests()
      .then(
        (response) => {
          console.log("response", response);
          dispatch(getListActions.success(response));
        },
        (err) => {
          throw err;
        }
      )
      .catch((err) => {
        dispatch(getListActions.failed(err));
      });
  };
};

export const getListActions = {
  started: () => {
    return {
      type: AVAILABLE_TESTS_STARTED,
    };
  },
  success: (data) => {
    return {
      type: AVAILABLE_TESTS_SUCCESS,
      payload: data.data,
    };
  },
  failed: (error) => {
    return {
      type: AVAILABLE_TESTS_FAILED,
      errors: error,
    };
  },
};

export const availableTestsReducer = (state = initialState, action) => {
  let newState = state;

  switch (action.type) {
    case AVAILABLE_TESTS_STARTED: {
      newState = update.set(state, "list.loading", true);
      newState = update.set(newState, "list.success", false);
      newState = update.set(newState, "list.failed", false);
      break;
    }
    case AVAILABLE_TESTS_SUCCESS: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.failed", false);
      newState = update.set(newState, "list.success", true);
      newState = update.set(newState, "list.data", action.payload);
      break;
    }
    case AVAILABLE_TESTS_FAILED: {
      newState = update.set(state, "list.loading", false);
      newState = update.set(newState, "list.success", false);
      newState = update.set(newState, "list.failed", true);
      break;
    }
    default: {
      return newState;
    }
  }
  return newState;
};
