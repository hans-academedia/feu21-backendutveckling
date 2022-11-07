import './App.css';
import CommentForm from './components/CommentForm';
import CustomerForm from './components/CustomerForm';
import IssueForm from './components/IssueForm';
import StatusForm from './components/StatusForm';

function App() {
  return (
    <>
      <div className="container mt-5">
        {/* <StatusForm /> */}
        {/* <CustomerForm /> */}
        {/* <IssueForm /> */}
        <CommentForm />
      </div>
    </>
  );
}

export default App;
